using Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public Guid Id { get; set; }
    }
}
