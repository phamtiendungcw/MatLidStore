using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MLS.Domain.Entities;

public class Tag : BaseEntity
{
    [MaxLength(50)] public string Name { get; set; } = string.Empty; // Tag name (e.g., "Electronics", "Clothing")

    public ICollection<ProductTag> ProductTags { get; set; } =
        new List<ProductTag>(); // One-to-Many relationship with ProductTag

    public ICollection<Article> Articles { get; set; } =
        new List<Article>(); // One-to-Many relationship with Article (optional)
}