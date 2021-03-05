using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //auto mapper uses reflection to map properties
            Mapper.CreateMap<Customer, CustomerDtos>();
            Mapper.CreateMap<CustomerDtos, Customer>();
        }
    }
}