using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MLS.Domain.Entities;

public class Address : BaseEntity
{
    [MaxLength(500)] public string Street { get; set; } = string.Empty;
    [MaxLength(50)] public string City { get; set; } = string.Empty;
    [MaxLength(50)] public string State { get; set; } = string.Empty;
    [MaxLength(50)] public string Country { get; set; } = string.Empty;
    [MaxLength(20)] public string PostalCode { get; set; } = string.Empty;

    public int UserId { get; set; } // Foreign key referencing AppUser
    public AppUser AppUser { get; set; } = null!; // Navigation property for AppUser
}