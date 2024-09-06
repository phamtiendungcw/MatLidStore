using FluentValidation.Results;

namespace MLS.Application.Exceptions;

public class BadRequestException : Exception
{
    // Constructor with message parameter
    public BadRequestException(string message) : base(message)
    {
        ValidationErrors = new Dictionary<string, string[]>();
    }

    // Constructor with message and validation result
    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        // Convert validation result errors to a dictionary
        ValidationErrors = validationResult.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
    }

    // Property to hold validation errors
    public IDictionary<string, string[]> ValidationErrors { get; }
}