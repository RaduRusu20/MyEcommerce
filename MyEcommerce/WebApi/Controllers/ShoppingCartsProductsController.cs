using Application.Products.Queries.GetProductById;
using Application.ShoppingCarts.Commands.AddProductToShoppingCart;
using Application.ShoppingCarts.Commands.RemoveProductFromShoppingCart;
using Application.ShoppingCarts.Queries.GetShoppingCartById;
using AutoMapper;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ShoppingCartsProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateShoppingCartProduct(ShoppingCartsProductsDto shoppingCartProduct)
        {
            var mappedShoppingCartProduct = _mapper.Map<ShoppingCartsProducts>(shoppingCartProduct);

            var shcart = await _mediator.Send(new GetShoppingCartByIdQuery
            {
                Id = mappedShoppingCartProduct.ShoppingCartId
            });

            var product = await _mediator.Send(new GetProductByIdQuery
            {
                Id = mappedShoppingCartProduct.ProductId
            });

            var command = new AddProductToShoppingCartCommand
            {
                Quantity = mappedShoppingCartProduct.Quantity,
                Product = product,
                ShoppingCart = shcart,
            };

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveShoppingCartProduct(ShoppingCartsProductsDto shoppingCartProduct)
        {
            var mappedShoppingCartProduct = _mapper.Map<ShoppingCartsProducts>(shoppingCartProduct);

            var product = await _mediator.Send(new GetProductByIdQuery
            {
                Id = mappedShoppingCartProduct.ProductId
            });

            var shoppingCart = await _mediator.Send(new GetShoppingCartByIdQuery
            {
                Id = mappedShoppingCartProduct.ShoppingCartId
            });

            var command = new RemoveProductFromShoppingCartCommand
            {
                Product = product,
                ShoppingCart = shoppingCart,
                Quantity = mappedShoppingCartProduct.Quantity
            };

            await _mediator.Send(command);

            return Ok();
        }


    }
}
