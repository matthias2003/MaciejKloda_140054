using CarRentalAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>()
             .HasOne(r => r.Car) 
             .WithOne(c => c.Rental)
             .HasForeignKey<Rental>(r => r.CarId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Rental)
                .WithOne(r => r.Car)
                .HasForeignKey<Rental>(r => r.CarId)
                .IsRequired(false);

        }
    }
}
