using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTemplate.Infrastructure.Logging;

namespace WebApiTemplate.Domain.Customers
{
    // api/customers
    public class CustomersController : ApiController
    {
        private readonly IMediator mediator;
        private readonly CustomersService service;

        public CustomersController(IMediator mediator, CustomersService service)
        {
            this.mediator = mediator;
            this.service = service;
        }

        // GET: api/customers
        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<CustomerDTO> customers;

            try
            {
                customers = await service.GetAllCustomers();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "CustomersService.GetAllCustomers encountered an exception.");
                return InternalServerError();
            }

            return Ok(customers);
        }

        // GET: api/customers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/customers
        [HttpPost]
        public async Task<IHttpActionResult> Post(CancellationToken cancellationToken, [FromBody] CustomerAddCommand command)
        {
            await this.mediator.Send(command, cancellationToken);

            return Ok();
        }

        // PUT: api/customers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/customers/5
        public void Delete(int id)
        {
        }
    }
}
