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
             .HasOne(r => r.Car)  // Rental ma jeden Car
             .WithOne(c => c.Rental)  // Car ma jeden Rental
             .HasForeignKey<Rental>(r => r.CarId)  // Klucz obcy w Rental wskazuje na Car
             .OnDelete(DeleteBehavior.Cascade);  // Jeśli Rental zostanie usunięty, usuwamy też Car

            // Zdefiniowano, że Car może (ale nie musi) mieć Rental
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Rental)  // Car ma jeden Rental
                .WithOne(r => r.Car)  // Rental ma jeden Car
                .HasForeignKey<Rental>(r => r.CarId)  // Klucz obcy w Rental wskazuje na Car
                .IsRequired(false);  // Opcjonalność relacji

        }
    }
}
