using DesignPatterns.Command.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace DesignPatterns.Command
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            using var scope = host.Services.CreateScope();
            var identityDbContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            
            // Automatic Migration.
            identityDbContext.Database.Migrate();

            if (!userManager.Users.Any())
            {
                userManager.CreateAsync(new AppUser { UserName = "user1", Email = "user1@outlook.com" }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser { UserName = "user2", Email = "user2@outlook.com" }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser { UserName = "user3", Email = "user3@outlook.com" }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser { UserName = "user4", Email = "user4@outlook.com" }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser { UserName = "user5", Email = "user5@outlook.com" }, "Password12*").Wait();

                Enumerable.Range(1, 30).ToList().ForEach(x =>
                {
                    identityDbContext.Product.Add(new Product() 
                    { 
                        Name = $"kalem {x}", 
                        Price = (decimal)(0.25 * x * new Random().Next(100)), 
                        Stock = new Random().Next(100) 
                    });
                });

                identityDbContext.SaveChangesAsync();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
