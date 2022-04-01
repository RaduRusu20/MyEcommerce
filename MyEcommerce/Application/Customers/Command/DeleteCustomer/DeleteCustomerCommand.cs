using Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Command.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Guid>
    {
        public Customer Customer { get; set; }
    }
}
