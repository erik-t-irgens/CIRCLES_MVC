using System;
using Circles_MVC.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;

[assembly: HostingStartup(typeof(Circles_MVC.Areas.Identity.IdentityHostingStartup))]
namespace Circles_MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<Circles_MVCIdentityDbContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("Circles_MVCIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<Circles_MVCIdentityDbContext>();
            });
        }
    }
}