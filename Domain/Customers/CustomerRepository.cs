using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiTemplate.Infrastructure.Data;

namespace WebApiTemplate.Domain.Customers
{
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public CustomerRepository(IDbTransaction transaction)
            : base(transaction)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await Connection.GetListAsync<Customer>(null, transaction: Transaction);
        }

        public async Task<int?> AddCustomer(Customer customer)
        {
            return await Connection.InsertAsync(customer, transaction: Transaction);
        }
    }
}