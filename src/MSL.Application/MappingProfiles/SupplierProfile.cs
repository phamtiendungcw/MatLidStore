﻿using AutoMapper;
using MLS.Application.DTO.Supplier;
using MLS.Application.Features.Supplier.Commands.CreateSupplierCommand;
using MLS.Application.Features.Supplier.Commands.DeleteSupplierCommand;
using MLS.Application.Features.Supplier.Commands.UpdateSupplierCommand;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierDto, Supplier>().ReverseMap();
            CreateMap<Supplier, SupplierDetailDto>();
            CreateMap<Supplier, CreateSupplierCommand>();
            CreateMap<Supplier, UpdateSupplierCommand>();
            CreateMap<Supplier, DeleteSupplierCommand>();
        }
    }
}
