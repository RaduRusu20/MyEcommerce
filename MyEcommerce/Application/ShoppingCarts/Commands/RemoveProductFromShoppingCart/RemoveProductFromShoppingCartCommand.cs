using Domain.Products;
using Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCarts.Commands.RemoveProductFromShoppingCart
{
    public class RemoveProductFromShoppingCartCommand : IRequest<Guid>
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
