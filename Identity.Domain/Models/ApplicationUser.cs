using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; }

        public string Address { get; set; }
    }
}