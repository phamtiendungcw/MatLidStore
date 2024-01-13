using MLS.Application.DTO.Product;
using MLS.Application.DTO.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLS.Application.DTO.CartItem
{
    public class CartItemDto
    {
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        // Các thuộc tính khác

        public virtual ShoppingCartDto ShoppingCart { get; set; }
        public virtual ProductDto Product { get; set; }
    }
}
