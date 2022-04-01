using Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCarts.Commands.DeleteShoppingCart
{
    public class DeleteShoppingCartCommand : IRequest<Guid>
    {
        public ShoppingCart ShoppingCart { get; set; }
    }
}
