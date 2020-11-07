using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiTemplate.Domain.Customers;

namespace WebApiTemplate.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Domain to DTO
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CustomerName));

            // DTO to Domain
            //CreateMap<CustomerDTO, Customer>()
            //    .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}