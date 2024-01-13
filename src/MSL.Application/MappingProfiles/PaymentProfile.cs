using AutoMapper;
using MLS.Application.DTO.Payment;
using MLS.Application.Features.Payment.Commands.CreatePaymentCommand;
using MLS.Application.Features.Payment.Commands.DeletePaymentCommand;
using MLS.Application.Features.Payment.Commands.UpdatePaymentCommand;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentDto, Payment>().ReverseMap();
            CreateMap<Payment, PaymentDetailDto>();
            CreateMap<Payment, CreatePaymentCommand>();
            CreateMap<Payment, UpdatePaymentCommand>();
            CreateMap<Payment, DeletePaymentCommand>();
        }
    }
}
