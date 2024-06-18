using FluentValidation;

namespace MLS.Application.DTO.Shipment
{
    public class CreateShipmentValidator : AbstractValidator<CreateShipmentDto>
    {
        public CreateShipmentValidator()
        {
            RuleFor(x => x.ShippingMethod)
                .NotEmpty().WithMessage("ShippingMethod cannot be empty.")
                .MaximumLength(100).WithMessage("Shipping Method cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.TrackingNumber)
                .NotEmpty().WithMessage("TrackingNumber cannot be empty.")
                .MaximumLength(50).WithMessage("Tracking Number cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.EstimatedDeliveryDate).GreaterThanOrEqualTo(DateTime.Now).WithMessage("Estimated Delivery Date cannot be in the past.");
            RuleFor(x => x.OrderId).GreaterThan(0).WithMessage("OrderId must be greater than 0.");
        }
    }

    public class UpdateShipmentValidator : AbstractValidator<UpdateShipmentDto>
    {
        public UpdateShipmentValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.ShippingMethod)
                .NotEmpty().WithMessage("ShippingMethod cannot be empty.")
                .MaximumLength(100).WithMessage("Shipping Method cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.TrackingNumber)
                .NotEmpty().WithMessage("TrackingNumber cannot be empty.")
                .MaximumLength(50).WithMessage("Tracking Number cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.EstimatedDeliveryDate).GreaterThanOrEqualTo(DateTime.Now).WithMessage("Estimated Delivery Date cannot be in the past.");
            RuleFor(x => x.OrderId).GreaterThan(0).WithMessage("OrderId must be greater than 0.");
        }
    }
}