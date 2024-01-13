using AutoMapper;
using MLS.Application.DTO.Inventory;
using MLS.Application.Features.Inventory.Commands.CreateInventoryCommand;
using MLS.Application.Features.Inventory.Commands.DeleteInventoryCommand;
using MLS.Application.Features.Inventory.Commands.UpdateInventoryCommand;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<InventoryDto, Inventory>().ReverseMap();
            CreateMap<Inventory, InventoryDetailDto>();
            CreateMap<Inventory, CreateInventoryCommand>();
            CreateMap<Inventory, UpdateInventoryCommand>();
            CreateMap<Inventory, DeleteInventoryCommand>();
        }
    }
}
