using System;
using WebApiTemplate.Domain.Customers;

namespace WebApiTemplate.Infrastructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }

        void Commit();
    }
}
