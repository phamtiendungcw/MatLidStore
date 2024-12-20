﻿using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MLS.Domain.Entities;

public class Article : BaseEntity
{
    [MaxLength(100)] public string Title { get; set; } = string.Empty; // Article title
    [MaxLength(2000)] public string Content { get; set; } = string.Empty; // Article content
    [MaxLength(100)] public string Author { get; set; } = string.Empty; // Author name
    public DateTime PublicationDate { get; set; } // Date and time of publication

    public int AuthorUserId { get; set; } // Foreign key referencing User (author)
    public AppUser AuthorUser { get; set; } = null!; // Navigation property for User

    public List<Comment> Comments { get; set; } = new(); // One-to-Many relationship with Comment
}