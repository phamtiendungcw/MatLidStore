using FluentValidation;

namespace MLS.Application.DTO.Shipment;

public class ShipmentDtoValidator : AbstractValidator<ShipmentDto>
{
    public ShipmentDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
        RuleFor(x => x.ShippingMethod)
            .NotEmpty().WithMessage("Shipping Method cannot be empty.")
            .MaximumLength(100).WithMessage("Shipping Method must be less than 100 characters.");
        RuleFor(x => x.TrackingNumber)
            .NotEmpty().WithMessage("Tracking Number cannot be empty.")
            .MaximumLength(50).WithMessage("Tracking Number must be less than 50 characters.");
        RuleFor(x => x.EstimatedDeliveryDate)
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Estimated Delivery Date cannot be in the past.");
        RuleFor(x => x.OrderId)
            .GreaterThan(0).WithMessage("OrderId must be greater than 0.");
    }
}

public class CreateShipmentDtoValidator : AbstractValidator<CreateShipmentDto>
{
    public CreateShipmentDtoValidator()
    {
        RuleFor(x => x.ShippingMethod)
            .NotEmpty().WithMessage("Shipping Method cannot be empty.")
            .MaximumLength(100).WithMessage("Shipping Method must be less than 100 characters.");
        RuleFor(x => x.TrackingNumber)
            .NotEmpty().WithMessage("Tracking Number cannot be empty.")
            .MaximumLength(50).WithMessage("Tracking Number must be less than 50 characters.");
        RuleFor(x => x.EstimatedDeliveryDate)
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Estimated Delivery Date cannot be in the past.");
        RuleFor(x => x.OrderId)
            .GreaterThan(0).WithMessage("OrderId must be greater than 0.");
    }
}

public class UpdateShipmentDtoValidator : AbstractValidator<UpdateShipmentDto>
{
    public UpdateShipmentDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
        RuleFor(x => x.ShippingMethod)
            .NotEmpty().When(x => x.ShippingMethod != null).WithMessage("Shipping Method cannot be empty.")
            .MaximumLength(100).WithMessage("Shipping Method must be less than 100 characters.");
        RuleFor(x => x.TrackingNumber)
            .NotEmpty().When(x => x.TrackingNumber != null).WithMessage("Tracking Number cannot be empty.")
            .MaximumLength(50).WithMessage("Tracking Number must be less than 50 characters.");
        RuleFor(x => x.EstimatedDeliveryDate)
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Estimated Delivery Date cannot be in the past.");
        RuleFor(x => x.OrderId)
            .GreaterThan(0).WithMessage("OrderId must be greater than 0.");
    }
}