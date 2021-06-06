using Entities.Concrete;
using DataAccess.Concrete.EntityFrameworkCore.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class HotelDbContext: IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=HotelDb;uid=sa;pwd=123;");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomTypeImage> RoomTypeImages { get; set; }
        public DbSet<RoomStatus> RoomStatuses { get; set; }
        public DbSet<BookingPackage> BookingPackages { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<PayrollForWorker> PayrollForWorkers { get; set; }
        public DbSet<PayrollForManager> PayrollForManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
