using Microsoft.AspNetCore.Identity;

namespace DesignPatterns.Command.Models
{
    public class AppUser : IdentityUser
    {
        public string City { get; set; }
    }
}
