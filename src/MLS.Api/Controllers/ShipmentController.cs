using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.Shipment;
using MLS.Application.Features.Shipment.Commands.CreateShipmentCommand;
using MLS.Application.Features.Shipment.Commands.DeleteShipmentCommand;
using MLS.Application.Features.Shipment.Commands.UpdateShipmentCommand;
using MLS.Application.Features.Shipment.Queries.GetAllShipments;
using MLS.Application.Features.Shipment.Queries.GetShipmentDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class ShipmentController : MatLidStoreBaseController
{
    private readonly IMediator _mediator;

    public ShipmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<ShipmentController>
    [HttpGet]
    public async Task<IReadOnlyList<ShipmentDto>> GetAllShipments()
    {
        var shipments = await _mediator.Send(new GetAllShipmentsQuery());
        return shipments;
    }

    // GET api/<ShipmentController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ShipmentDetailsDto>> GetShipment(int id)
    {
        var shipment = await _mediator.Send(new GetShipmentDetailsQuery(id));
        return Ok(shipment);
    }

    // POST api/<ShipmentController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateShipment([FromBody] CreateShipmentCommand shipment)
    {
        var response = await _mediator.Send(shipment);
        return CreatedAtAction(nameof(CreateShipment), new { id = response });
    }

    // PUT api/<ShipmentController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateShipment([FromBody] UpdateShipmentCommand shipment)
    {
        await _mediator.Send(shipment);
        return NoContent();
    }

    // DELETE api/<ShipmentController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteShipment(int id)
    {
        var command = new DeleteShipmentCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}