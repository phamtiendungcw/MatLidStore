namespace MLS.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<ProductOption> ProductOptions { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<ProductReview> Reviews { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}