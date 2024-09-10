using MLS.Application.DTO.Product;
using MLS.Application.DTO.WishList;

namespace MLS.Application.DTO.WishListItem;

public class WishListItemDetailsDto : WishListItemDto
{
    public ProductDto Product { get; set; } = new();
    public WishListDto WishList { get; set; } = new();
}