﻿using MLS.Application.DTO.User;

namespace MLS.Application.DTO.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int ArticleId { get; set; }
    }
}