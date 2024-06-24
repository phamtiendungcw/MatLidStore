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

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<IReadOnlyList<Address>> GetAllAddresses()
        {
            var addresses = await _addressRepository.GetAllAsync();
            return addresses;
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDetailsDto>> GetAddress(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);

            if (address is null)
                throw new NotFoundException(nameof(Address), id);

            return Ok(address);
        }

        // POST api/<AddressController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void CreateAddress([FromBody] CreateAddressDto address)
        {
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public void UpdateAddress([FromBody] UpdateAddressDto address)
        {
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public void DeleteAddress(int id)
        {
        }
    }
}