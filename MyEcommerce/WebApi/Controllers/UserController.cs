using Application.ShoppingCarts.Commands;
using Application.Users.Command.CreateCustomer;
using Application.Users.Command.DeleteCustomer;
using Application.Users.Command.UpdateUser;
using Application.Users.Queries.GetCustomerById;
using Application.Users.Queries.GetCustomers;
using Application.Users.Queries.GetUserIdByEmail;
using AutoMapper;
using Domain;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using Azure.Storage.Blobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace WebApi.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUserByIdQuery
            {
                Id = id
            };

            var result = await _mediator.Send(query);
            var dtoResult = _mapper.Map<UserDto>(result);
            return Ok(dtoResult);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var query = new GetUserByEmailQuery
            {
                Email = email
            };
            var result = await _mediator.Send(query);
            var dtoResult = _mapper.Map<UserDto>(result);
            return Ok(dtoResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();

            var result = await _mediator.Send(query);
            var dtoResult = _mapper.Map<List<UserDto>>(result);
            return Ok(dtoResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto user)
        {
            var commandUser = new CreateUserCommand
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Adress = user.Adress,
                Role = user.Role,
                ProfileImgUrl = user.ProfileImgUrl
            };

            var userId = await _mediator.Send(commandUser);

            return Created($"/Users/{userId}", null);
        }

        [Route("UploadPhoto")]
        [HttpPost]
        public async Task<IActionResult> UploadPhoto(IFormFile image)
        {
            var blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=myecommerce12;AccountKey=8RTMxbDR61HS0VoBpz82pRFRv3q0A6t4t1k6BbDmWTZcLKuGmV/wczbgRlb1kH6oR6y5lVe0OEAJ+AStNMg9YQ==;EndpointSuffix=core.windows.net";
            var blobStorageContainerName = "files";


            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobStorageConnectionString);
            // Create the blob client.    
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            // Retrieve a reference to a container.    
            CloudBlobContainer container = blobClient.GetContainerReference(blobStorageContainerName);
            // This also does not make a service call; it only creates a local object.    
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(Guid.NewGuid().ToString() + ".png");
            await using (var data = image.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(data);
            }
            return Ok(blockBlob.StorageUri.PrimaryUri.AbsoluteUri);
        }

        [Route("GetPhoto")]
        [HttpGet]
        public async Task<IActionResult> GetPhoto(string fileName)
        {
            var blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=myecommerce12;AccountKey=8RTMxbDR61HS0VoBpz82pRFRv3q0A6t4t1k6BbDmWTZcLKuGmV/wczbgRlb1kH6oR6y5lVe0OEAJ+AStNMg9YQ==;EndpointSuffix=core.windows.net";
            var blobStorageContainerName = "files";


            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobStorageConnectionString);
            // Create the blob client.    
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            // Retrieve a reference to a container.    
            CloudBlobContainer container = blobClient.GetContainerReference(blobStorageContainerName);
            // This also does not make a service call; it only creates a local object.    
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            return Ok(blockBlob.StorageUri.PrimaryUri.AbsoluteUri);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { Id = userId });

            var command = new DeleteUserCommand
            {
                User = user
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPatch("{userId}")]
        public async Task<IActionResult> UpdateUser(UserDto newUser, Guid userId)
        {
            var user = _mapper.Map<User>(newUser);

            user.Password = MyCryptography.EncryptPlainTextToCipherText(user.Password);

            var command = new UpdateUserCommand
            {
                Id = userId,
                User = user
            };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
