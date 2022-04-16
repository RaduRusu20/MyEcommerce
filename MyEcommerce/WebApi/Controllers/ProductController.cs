using Application.Products.Commands;
using Application.Products.Queries;
using Application.Products.Queries.GetProductById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var query = new GetProductByIdQuery
            {
                Id = id
            };

            var result = await _mediator.Send(query);
            var dtoResult = _mapper.Map<ProductDto>(result);
            return Ok(dtoResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var query = new GetProductsQuery();
           
            var result = await _mediator.Send(query);
            var dtoResult = _mapper.Map<List<ProductDto>>(result);
            return Ok(dtoResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto product)
        {
            var command = new CreateProductCommand
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                AvailableQuantity = product.AvailableQuantity,
                CategoryId = product.CategoryId
            };

            await _mediator.Send(command);

            return Ok(product);
        }
    }
}
