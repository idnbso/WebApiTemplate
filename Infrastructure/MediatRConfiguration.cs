using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using WebApiTemplate.Domain.Customers;

namespace WebApiTemplate.Infrastructure
{
    public class MediatRConfiguration
    {
        public static IEnumerable<Assembly> GetAssemblies()
        {
            var assemblies = new List<Assembly>() 
            { 
                typeof(CustomerAddCommand).Assembly 
            };

            return assemblies;
        }
    }
}