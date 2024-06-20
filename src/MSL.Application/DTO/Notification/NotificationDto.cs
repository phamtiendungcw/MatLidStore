﻿namespace MLS.Application.DTO.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public int UserId { get; set; }
    }
}