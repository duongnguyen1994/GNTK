using GNTK.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.DAL.Implement
{
    public class AppDbContext: IdentityDbContext<AppIdentityUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
            builder.Entity<Booking>()
                    .HasOne<AppIdentityUser>(b => b.Customer)
                    .WithMany(c => c.CustomerBookings)
                    .HasForeignKey(cb => cb.CustomerId);
            builder.Entity<Booking>()
                    .HasOne<AppIdentityUser>(b => b.Driver)
                    .WithMany(c => c.DriverBookings)
                    .HasForeignKey(cb => cb.DriverId);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "1",
                    Name = "Customer"
                },
                new IdentityRole()
                {
                    Id = "2",
                    Name = "Driver"
                }, new IdentityRole()
                {
                    Id = "3",
                    Name = "Switchboard"
                });
        }
    }
}
