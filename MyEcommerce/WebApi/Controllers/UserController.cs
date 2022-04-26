using Application.ShoppingCarts.Commands;
using Application.Users.Command.CreateCustomer;
using Application.Users.Command.DeleteCustomer;
using Application.Users.Command.UpdateUser;
using Application.Users.Queries.GetCustomerById;
using Application.Users.Queries.GetCustomers;
using AutoMapper;
using Domain;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

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
            };

            var userId = await _mediator.Send(commandUser);

            if (user.Role == Domain.Roles.Role.Customer)
            {
                var userGet = await _mediator.Send(new GetUserByIdQuery { Id = userId });
                var commandSHc = new CreateShoppingCartCommand
                {
                    User = userGet
                };
                await _mediator.Send(commandSHc);
            }

            return Ok(user);
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
            return Ok(userId);
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

            return Ok(userId);
        }
    }
}
