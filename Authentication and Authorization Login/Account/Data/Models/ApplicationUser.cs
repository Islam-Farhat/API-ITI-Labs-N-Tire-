using Microsoft.AspNetCore.Identity;

namespace Account.Data.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
