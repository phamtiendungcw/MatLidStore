using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Supply;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers
{
    public class SupplyController : MatLidStoreBaseController
    {
        private readonly ISupplyRepository _supplyRepository;
        private readonly IMapper _mapper;

        public SupplyController(ISupplyRepository supplyRepository, IMapper mapper)
        {
            _supplyRepository = supplyRepository;
            _mapper = mapper;
        }

        // GET: api/<SupplyController>
        [HttpGet]
        public async Task<IReadOnlyList<SupplyDto>> GetAllSupplies()
        {
            var supplies = await _supplyRepository.GetAllAsync();
            var data = _mapper.Map<List<SupplyDto>>(supplies);
            return data;
        }

        // GET api/<SupplyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplyDetailsDto>> GetSupply(int id)
        {
            var supply = await _supplyRepository.GetByIdAsync(id);

            if (supply is null || supply.IsDeleted)
                throw new NotFoundException(nameof(Supply), id);

            var data = _mapper.Map<SupplyDetailsDto>(supply);
            return Ok(data);
        }

        // POST api/<SupplyController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateSupply([FromBody] CreateSupplyDto supply)
        {
            var supplyToCreate = _mapper.Map<Supply>(supply);
            await _supplyRepository.CreateAsync(supplyToCreate);
            return CreatedAtAction(nameof(CreateSupply), supplyToCreate.Id);
        }

        // PUT api/<SupplyController>/5
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateSupply([FromBody] UpdateSupplyDto supply)
        {
            var supplyToUpdate = _mapper.Map<Supply>(supply);
            await _supplyRepository.UpdateAsync(supplyToUpdate);
            return NoContent();
        }

        // DELETE api/<SupplyController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteSupply(int id)
        {
            var supplyToDelete = await _supplyRepository.GetByIdAsync(id);

            if (supplyToDelete is null || supplyToDelete.IsDeleted)
                throw new NotFoundException(nameof(Supply), id);

            await _supplyRepository.DeleteAsync(supplyToDelete);
            return NoContent();
        }
    }
}