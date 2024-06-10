using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }
}