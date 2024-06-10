namespace MLS.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public int? DiscountId { get; set; }
        public Discount Discount { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Shipment> Shipments { get; set; }
    }
}