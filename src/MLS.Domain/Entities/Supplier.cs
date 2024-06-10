namespace MLS.Domain.Entities
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public ICollection<Supply> Supplies { get; set; }
    }
}