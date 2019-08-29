using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Circles_MVC.Models
{
    public class Circles_MVCContext : IdentityDbContext<ApplicationUser>
    {
        public Circles_MVCContext (DbContextOptions<Circles_MVCContext> options)
            : base(options)
        {
        }
    }
}
