using Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCarts.Queries
{
    public class GetShoppingCartsQuery : IRequest<List<ShoppingCart>>
    {
    }
}
