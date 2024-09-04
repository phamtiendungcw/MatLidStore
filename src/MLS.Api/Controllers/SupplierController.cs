using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Supplier;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class SupplierController : MatLidStoreBaseController
{
    private readonly IMapper _mapper;
    private readonly ISupplierRepository _supplierRepository;

    public SupplierController(ISupplierRepository supplierRepository, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    // GET: api/<SupplierController>
    [HttpGet]
    public async Task<IReadOnlyList<SupplierDto>> GetAllSuppliers()
    {
        var suppliers = await _supplierRepository.GetAllAsync();
        var data = _mapper.Map<List<SupplierDto>>(suppliers);
        return data;
    }

    // GET api/<SupplierController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SupplierDetailsDto>> GetSupplier(int id)
    {
        var supplier = await _supplierRepository.GetByIdAsync(id);

        if (supplier is null)
            throw new NotFoundException(nameof(Supplier), id);

        var data = _mapper.Map<SupplierDetailsDto>(supplier);
        return Ok(data);
    }

    // POST api/<SupplierController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateSupplier([FromBody] CreateSupplierDto supplier)
    {
        var supplierToCreate = _mapper.Map<Supplier>(supplier);
        await _supplierRepository.CreateAsync(supplierToCreate);
        return CreatedAtAction(nameof(CreateSupplier), supplierToCreate.Id);
    }

    // PUT api/<SupplierController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateSupplier([FromBody] UpdateSupplierDto supplier)
    {
        var supplierToUpdate = _mapper.Map<Supplier>(supplier);
        await _supplierRepository.UpdateAsync(supplierToUpdate);
        return NoContent();
    }

    // DELETE api/<SupplierController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteSupplier(int id)
    {
        var supplierToDelete = await _supplierRepository.GetByIdAsync(id);

        if (supplierToDelete is null)
            throw new NotFoundException(nameof(Supplier), id);

        await _supplierRepository.DeleteAsync(supplierToDelete);
        return NoContent();
    }
}