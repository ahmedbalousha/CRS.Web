using CRS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRS.Data
{
    public class CRSDbContext : IdentityDbContext<User>
    {
        public CRSDbContext(DbContextOptions<CRSDbContext> options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<UserContract>().HasKey(x => new { x.CarRentalId, x.CustomerId,x.ContractId });
        //    //builder.Entity<BaseEntity>().HasQueryFilter(x => !x.IsDelete);
        //    //builder.Entity<User>().HasQueryFilter(x => !x.IsDelete);


        //}
        public DbSet<Car> Cars { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<CarCompany> CarCompanies { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<CarChangeLog> CarChangeLogs { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        //public DbSet<UserContract> UserContracts { get; set; }

    }
}
