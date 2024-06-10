namespace MLS.Domain.Entities
{
    public class ProductColor
    {
        public int ProductColorId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; } // Hex code for color, e.g., #FFFFFF
    }
}