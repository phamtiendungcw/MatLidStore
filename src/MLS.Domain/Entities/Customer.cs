namespace MLS.Domain.Entities
{
    public class Customer : User
    {
        public Entities.Address DeliveryAddress { get; set; }
        public Entities.Address BillingAddress { get; set; }
        public List<Entities.Order> Orders { get; set; }
        public List<Entities.Review> Reviews { get; set; }
    }
}
