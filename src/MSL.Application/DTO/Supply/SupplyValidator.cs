using FluentValidation;

namespace MLS.Application.DTO.Supply
{
    public class CreateSupplyValidator : AbstractValidator<CreateSupplyDto>
    {
        public CreateSupplyValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.SupplierId).GreaterThan(0).WithMessage("SupplierId must be greater than 0.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }

    public class UpdateSupplyValidator : AbstractValidator<UpdateSupplyDto>
    {
        public UpdateSupplyValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.SupplierId).GreaterThan(0).WithMessage("SupplierId must be greater than 0.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}