using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Command.Models
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Product> Product { get; set; }
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }
    }
}
