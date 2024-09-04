using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Notification;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class NotificationController : MatLidStoreBaseController
{
    private readonly IMapper _mapper;
    private readonly INotificationRepository _notificationRepository;

    public NotificationController(INotificationRepository notificationRepository, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }

    // GET: api/<NotificationController>
    [HttpGet]
    public async Task<IReadOnlyList<NotificationDto>> GetAllNotifications()
    {
        var notifications = await _notificationRepository.GetAllAsync();
        var data = _mapper.Map<List<NotificationDto>>(notifications);

        return data;
    }

    // GET api/<NotificationController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<NotificationDetailsDto>> GetNotification(int id)
    {
        var notification = await _notificationRepository.GetByIdAsync(id);

        if (notification is null)
            throw new NotFoundException(nameof(Notification), id);

        var data = _mapper.Map<NotificationDetailsDto>(notification);

        return Ok(data);
    }

    // GET api/<NotificationController>/5
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<NotificationDto>>> GetUnreadNotificationsByUserId(int userId)
    {
        var notification = await _notificationRepository.GetUnreadNotificationsByUserIdAsync(userId);

        if (notification is null)
            throw new NotFoundException(nameof(Notification), userId);

        var data = _mapper.Map<List<NotificationDto>>(notification);

        return Ok(data);
    }

    // POST api/<NotificationController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateNotification([FromBody] CreateNotificationDto notification)
    {
        var notificationToCreate = _mapper.Map<Notification>(notification);
        await _notificationRepository.CreateAsync(notificationToCreate);

        return CreatedAtAction(nameof(CreateNotification), notificationToCreate.Id);
    }

    // PUT api/<NotificationController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateNotification([FromBody] UpdateNotificationDto notification)
    {
        var notificationToUpdate = _mapper.Map<Notification>(notification);
        await _notificationRepository.UpdateAsync(notificationToUpdate);

        return NoContent();
    }

    // DELETE api/<NotificationController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteNotification(int id)
    {
        var notificationToDelete = await _notificationRepository.GetByIdAsync(id);

        if (notificationToDelete is null)
            throw new NotFoundException(nameof(Notification), id);

        await _notificationRepository.DeleteAsync(notificationToDelete);

        return NoContent();
    }
}