namespace MLS.Domain.Entities
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}