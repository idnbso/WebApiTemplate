using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebApiTemplate.Infrastructure.Data;

namespace WebApiTemplate.Domain.Customers
{
    public class CustomerAddCommandHandler : IRequestHandler<CustomerAddCommand>
    {
        public async Task<Unit> Handle(CustomerAddCommand request, CancellationToken cancellationToken)
        {
            using (var uow = new UnitOfWork())
            {
                var id = await uow.CustomerRepository.AddCustomer(new Customer() { Id = request.Id, CustomerName = request.Name });

                uow.Commit();
            }

            return Unit.Value;
        }
    }
}