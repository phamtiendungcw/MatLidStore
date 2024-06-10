namespace MLS.Domain.Entities
{
    public class ProductOption
    {
        public int ProductOptionId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string OptionName { get; set; }
        public string OptionValue { get; set; }
    }
}