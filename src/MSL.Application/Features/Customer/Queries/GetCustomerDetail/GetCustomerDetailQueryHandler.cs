﻿using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence;
using MLS.Application.DTO.Customer;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Customer.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDetailDto> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetById(request.Id);

            if (customer == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Customer), request.Id);
            }

            var data = _mapper.Map<CustomerDetailDto>(customer);
            return data;
        }
    }
}