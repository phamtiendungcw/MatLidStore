using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Address;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers
{
    public class AddressController : MatLidStoreBaseController
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<IReadOnlyList<AddressDto>> GetAllAddresses()
        {
            var addresses = await _addressRepository.GetAllAsync();
            var data = _mapper.Map<List<AddressDto>>(addresses);
            return data;
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDetailsDto>> GetAddress(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);

            if (address is null || address.IsDeleted)
                throw new NotFoundException(nameof(Address), id);

            return Ok(address);
        }

        // POST api/<AddressController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateAddress([FromBody] CreateAddressDto address)
        {
            var addressToCreate = _mapper.Map<Address>(address);
            await _addressRepository.CreateAsync(addressToCreate);

            return CreatedAtAction(nameof(CreateAddress), new { id = addressToCreate.Id });
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateAddress([FromBody] UpdateAddressDto address)
        {
            var addressToUpdate = _mapper.Map<Address>(address);
            await _addressRepository.UpdateAsync(addressToUpdate);

            return NoContent();
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            var addressToDelete = await _addressRepository.GetByIdAsync(id);

            if (addressToDelete is null || addressToDelete.IsDeleted)
                throw new NotFoundException(nameof(Address), id);

            await _addressRepository.DeleteAsync(addressToDelete);

            return NoContent();
        }
    }
}