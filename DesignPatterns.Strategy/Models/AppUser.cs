using Microsoft.AspNetCore.Identity;

namespace DesignPatterns.Base.Models
{
    public class AppUser : IdentityUser
    {
        public string City { get; set; }
    }
}
