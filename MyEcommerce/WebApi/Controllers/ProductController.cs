using Application.Products.Commands;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries;
using Application.Products.Queries.GetProductById;
using Application.Products.Queries.GetProductsByCategoryId;
using AutoMapper;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/Products")]
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

        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetProductById(Guid ProductId)
        {
            var query = new GetProductByIdQuery
            {
                Id = ProductId
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

            var id = await _mediator.Send(command);

            return Created($"/Products/{id}", null);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var product =  await _mediator.Send(new GetProductByIdQuery { Id = productId });
            var command = new DeleteProductCommand
            {
                Product = product
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{productId}")]
        public async Task<IActionResult> UpdateProduct(ProductDto product, Guid productId)
        {
            var newProduct = _mapper.Map<Product>(product);
            var command = new UpdateProductCommand
            {
                Id = productId,
                Product = newProduct
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
