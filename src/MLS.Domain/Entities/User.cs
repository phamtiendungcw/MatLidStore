using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
