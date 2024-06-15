using MLS.Application.DTO.Product;
using MLS.Application.DTO.WishList;

namespace MLS.Application.DTO.WishListItem
{
    public class WishListItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int WishListId { get; set; }
        public WishListDto WishList { get; set; }
    }
}