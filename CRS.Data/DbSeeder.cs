using CRS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Data
{
    public static class DbSeeder
    {
        public static IHost SeedDb(this IHost webHost)
        {
            using var scope = webHost.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<CRSDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                context.SeedCategory().Wait();
                userManager.SeedUser().Wait();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return webHost;
        }

        public static async Task SeedCategory(this CRSDbContext _db)
        {
            if(await _db.CarCompanies.AnyAsync())
            {
                return;
            }

            var carCompanies = new List<CarCompany>();

            var carCompany = new CarCompany();
            carCompany.Name = "A1";
            carCompany.CreatedAt = DateTime.Now;

            var carCompany2 = new CarCompany();
            carCompany2.Name = "A2";
            carCompany2.CreatedAt = DateTime.Now;

            carCompanies.Add(carCompany);
            carCompanies.Add(carCompany2);

            await _db.CarCompanies.AddRangeAsync(carCompanies);
            await _db.SaveChangesAsync();
        }

        public static async Task SeedUser(this UserManager<User> userManger)
        {
            if (await userManger.Users.AnyAsync())
            {
                return;
            }
            var user = new User();
            user.FullName = "System Developer";
            user.UserName = "dev@gmail.com";
            user.Email = "dev@gmail.com";
            user.CreatedAt = DateTime.Now;

            await userManger.CreateAsync(user, "Admin111$$");
        }


    }
}
