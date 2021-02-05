using MediatR;

namespace WebApiTemplate.Domain.Customers
{
    public class CustomerAddCommand : IRequest
    {
        public int Id { get; }

        public string Name { get; }

        public CustomerAddCommand(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}