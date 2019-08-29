using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Circles_MVC.Models;
using Microsoft.AspNetCore.Identity;

namespace Circles_MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Use SQL Database if in Azure, otherwise, use SQLite
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            
                services.AddDbContext<Circles_MVCContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")));
            else
                services.AddDbContext<Circles_MVCContext>(options =>
                        options.UseSqlite("Data Source=localdatabase.db"));

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<Circles_MVCContext>().Database.Migrate();


             services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Circles_MVCContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Todos}/{action=Index}/{id?}");
            });
        }
    }
}

// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Http;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Circles_MVC.Models;
// using Microsoft.AspNetCore.Identity;

// namespace Circles_MVC
// {
//     public class Startup
//     {
//         public Startup(IHostingEnvironment env)
//         {
//             var builder = new ConfigurationBuilder()
//                 .SetBasePath(env.ContentRootPath)
//                 .AddJsonFile("appsettings.json");
//             Configuration = builder.Build();
//         }
//         public IConfigurationRoot Configuration { get; set; }
//         public void ConfigureServices(IServiceCollection services)
//         {
//             services.AddMvc();

//             services.AddEntityFrameworkMySql()
//                 .AddDbContext<Circles_MVCContext>(options => options
//                 .UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));

//             services.AddIdentity<ApplicationUser, IdentityRole>()
//                 .AddEntityFrameworkStores<Circles_MVCContext>()
//                 .AddDefaultTokenProviders();

//             services.Configure<IdentityOptions>(options =>
//             {
//                 options.Password.RequireDigit = false;
//                 options.Password.RequiredLength = 0;
//                 options.Password.RequireLowercase = false;
//                 options.Password.RequireNonAlphanumeric = false;
//                 options.Password.RequireUppercase = false;
//                 options.Password.RequiredUniqueChars = 0;
//             });
//         }
//         public void Configure(IApplicationBuilder app)
//         {
//             app.UseStaticFiles();
//             app.UseDeveloperExceptionPage();
//             app.UseAuthentication();
//             app.UseMvc(routes =>
//             {
//                 routes.MapRoute(
//                     name: "default",
//                     template: "{controller=Home}/{action=Index}/{id?}");
//             });

//             app.Run(async (context) =>
//             {
//                 await context.Response.WriteAsync("MVC Error");
//             });
//         }
//     }
// }