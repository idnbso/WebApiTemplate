using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiTemplate.Domain.Customers
{
    // api/customers
    public class CustomersController : ApiController
    {
        private readonly CustomersService service;

        public CustomersController(CustomersService service)
        {
            this.service = service;
        }

        // GET: api/customers
        public async Task<IHttpActionResult> Get()
        {
            var customers = await service.GetAllCustomers();
            return Ok(customers);
        }

        // GET: api/customers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/customers
        public void Post([FromBody]string value)
        {
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
