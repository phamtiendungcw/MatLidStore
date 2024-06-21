using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class WishListItem : BaseEntity
    {
        public int ProductId { get; set; } // Foreign key referencing Product
        public Product Product { get; set; } = null!; // Navigation property for Product

        public int WishListId { get; set; } // Foreign key referencing WishList
        public WishList WishList { get; set; } = null!; // Navigation property for WishList
    }
}