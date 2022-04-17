﻿using Application.Products.Commands;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Queries;
using Application.Products.Queries.GetProductById;
using Application.Products.Queries.GetProductsByCategoryId;
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
        
        /*
        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetProductsByCategory(Guid CategoryId)
        {
            var query = new GetProductsByCategoryIdQuery
            {
                CategoryId = CategoryId
            };

            var listOfProducts = await _mediator.Send(query);
            var dtoListOfProducts = _mapper.Map<List<ProductDto>>(listOfProducts);

            return Ok(dtoListOfProducts);
        }
        */
        

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

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var product =  await _mediator.Send(new GetProductByIdQuery { Id = productId });
            var command = new DeleteProductCommand
            {
                Product = product
            };

            await _mediator.Send(command);

            return Ok(productId);
        }
    }
}
