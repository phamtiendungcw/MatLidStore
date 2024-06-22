using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLS.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        [Column(TypeName = "decimal(3,2)")] public decimal Percentage { get; set; } // Percentage discount off the price
        public DateTime StartDate { get; set; } // Start date of the discount
        public DateTime EndDate { get; set; } // End date of the discount
    }
}