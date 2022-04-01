using Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCarts.Queries.GetShoppingCartById
{
    public class GetShoppingCartByIdQuery : IRequest<ShoppingCart>
    {
        public Guid Id { get; set; }
    }
}
