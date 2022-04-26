using Domain.Products;
using Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCarts.Commands.AddProductToShoppingCart
{
    public class AddProductToShoppingCartCommand : IRequest<Guid>
    {
        public ShoppingCart ShoppingCart { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
