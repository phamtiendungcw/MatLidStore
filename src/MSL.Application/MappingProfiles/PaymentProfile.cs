using AutoMapper;
using MLS.Application.DTO.Payment;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentDto, Payment>().ReverseMap();
            CreateMap<Payment, PaymentDetailsDto>();
            CreateMap<Payment, CreatePaymentDto>();
            CreateMap<Payment, UpdatePaymentDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}