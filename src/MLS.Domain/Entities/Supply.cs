namespace MLS.Domain.Entities
{
    public class Supply
    {
        public int SupplyId { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime SupplyDate { get; set; }
        public int Quantity { get; set; }
    }
}