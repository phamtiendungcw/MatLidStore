using FluentValidation;

namespace MLS.Application.DTO.Supply;

public class SupplyDtoValidator : AbstractValidator<SupplyDto>
{
    public SupplyDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        RuleFor(x => x.SupplierId)
            .GreaterThan(0).WithMessage("SupplierId must be greater than 0.");
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}

public class CreateSupplyDtoValidator : AbstractValidator<CreateSupplyDto>
{
    public CreateSupplyDtoValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        RuleFor(x => x.SupplierId)
            .GreaterThan(0).WithMessage("SupplierId must be greater than 0.");
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}

public class UpdateSupplyDtoValidator : AbstractValidator<UpdateSupplyDto>
{
    public UpdateSupplyDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        RuleFor(x => x.SupplierId)
            .GreaterThan(0).WithMessage("SupplierId must be greater than 0.");
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}