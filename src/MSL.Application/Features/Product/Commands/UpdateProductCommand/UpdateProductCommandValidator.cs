using FluentValidation;
using MLS.Application.DTO.Product;

namespace MLS.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductCommandValidator()
        {
        }
    }
}