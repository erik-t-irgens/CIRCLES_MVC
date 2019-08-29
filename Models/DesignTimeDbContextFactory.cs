// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;
// using System.IO;

// namespace Circles_MVC.Models
// {
//     public class Circles_MVCContextFactory : IDesignTimeDbContextFactory<Circles_MVCContext>
//     {
//         Circles_MVCContext IDesignTimeDbContextFactory<Circles_MVCContext>.CreateDbContext(string[] args)
//         {
//             IConfigurationRoot configuration = new ConfigurationBuilder()
//                 .SetBasePath(Directory.GetCurrentDirectory())
//                 .AddJsonFile("appsettings.json")
//                 .Build();

//             var builder = new DbContextOptionsBuilder<Circles_MVCContext>();
//             var connectionString = configuration.GetConnectionString("DefaultConnection");

//             builder.UseMySql(connectionString);

//             return new Circles_MVCContext(builder.Options);
//         }
//     }
// }