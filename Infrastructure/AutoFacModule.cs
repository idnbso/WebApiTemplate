using Autofac;
using Autofac.Core;
using AutoMapper;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using System.Configuration;
using WebApiTemplate.Domain.Customers;
using WebApiTemplate.Infrastructure.Data;

namespace WebApiTemplate.Infrastructure
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<AutoMapperProfile>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            builder.RegisterType<CustomersService>()
                   .InstancePerLifetimeScope();
        }
    }
}