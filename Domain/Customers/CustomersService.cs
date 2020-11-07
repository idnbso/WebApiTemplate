using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiTemplate.Infrastructure.Data;

namespace WebApiTemplate.Domain.Customers
{
    public class CustomersService
    {
        private IMapper mapper;

        public CustomersService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            IEnumerable<Customer> customers;

            using (var uow = new UnitOfWork())
            {
                customers = await uow.CustomerRepository.GetAllCustomers();

            }

            return mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);
        }
    }
}