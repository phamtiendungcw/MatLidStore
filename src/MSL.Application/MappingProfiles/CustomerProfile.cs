﻿using AutoMapper;
using MLS.Application.DTO.Customer;
using MLS.Application.Features.Customer.Commands.CreateCustomerCommand;
using MLS.Application.Features.Customer.Commands.DeleteCustomerCommand;
using MLS.Application.Features.Customer.Commands.UpdateCustomerCommand;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<Customer, CustomerDetailDto>();
            CreateMap<Customer, CreateCustomerCommand>();
            CreateMap<Customer, UpdateCustomerCommand>();
            CreateMap<Customer, DeleteCustomerCommand>();
        }
    }
}
