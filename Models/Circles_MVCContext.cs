using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Circles_MVC.Models
{
    public class Circles_MVCContext : IdentityDbContext<ApplicationUser>
    {
        public Circles_MVCContext(DbContextOptions options) : base(options) { }
    }
}