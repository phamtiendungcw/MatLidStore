﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLS.Application.Models.Identity;

public class RegistrationRequest
{
    public string Username { get; set; } = string.Empty;
    [EmailAddress] public string Email { get; set; } = string.Empty;
    [Phone] public string PhoneNumber { get; set; } = string.Empty; // User's phone number
    [NotMapped] public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty; // User's FirstName
    public string LastName { get; set; } = string.Empty; // User's LastName
}