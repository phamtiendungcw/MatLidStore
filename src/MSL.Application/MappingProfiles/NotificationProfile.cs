using AutoMapper;
using MLS.Application.DTO.Notification;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles;

public class NotificationProfile : Profile
{
    public NotificationProfile()
    {
        CreateMap<NotificationDto, Notification>().ReverseMap();
        CreateMap<Notification, NotificationDetailsDto>();
        CreateMap<CreateNotificationDto, Notification>();
        CreateMap<UpdateNotificationDto, Notification>();
    }
}