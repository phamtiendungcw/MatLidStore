﻿using MediatR;
using MLS.Application.Contracts.Persistence;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Product.Commands.DeleteProductImageCommand
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, Unit>
    {
        private readonly IProductImageRepository _productImageRepository;

        public DeleteProductImageCommandHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<Unit> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImageToDelete = await _productImageRepository.GetById(request.Id);

            if (productImageToDelete == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.ProductImage), request.Id);
            }

            await _productImageRepository.Delete(productImageToDelete);

            return Unit.Value;
        }
    }
}