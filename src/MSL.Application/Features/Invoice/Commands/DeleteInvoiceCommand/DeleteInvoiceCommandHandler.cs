﻿using MediatR;
using MLS.Application.Contracts.Persistence;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Invoice.Commands.DeleteInvoiceCommand
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, Unit>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public DeleteInvoiceCommandHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoiceToDelete = await _invoiceRepository.GetById(request.Id);

            if (invoiceToDelete == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Invoice), request.Id);
            }

            await _invoiceRepository.Delete(invoiceToDelete);

            return Unit.Value;
        }
    }
}