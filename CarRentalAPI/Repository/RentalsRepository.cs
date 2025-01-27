using CarRentalAPI.Data;
using CarRentalAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Repository
{
    public class RentalRepository : IRentalRepository
    {
        private readonly DataContext _context;

        public RentalRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rental>> GetRentalsAsync()
        {
            return await _context.Rentals.Include(r => r.Car).ToListAsync();
        }

        public async Task<Rental> CreateRentalAsync(Rental rental)
        {
            if (rental == null || rental.CarId == 0 || string.IsNullOrEmpty(rental.CustomerName) ||
                rental.RentalStartDate == DateTime.MinValue || rental.RentalEndDate == DateTime.MinValue)
            {
                throw new ArgumentException("Invalid rental data.");
            }

            var car = await _context.Car.FindAsync(rental.CarId);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {rental.CarId} not found.");
            }

            var newRental = new Rental
            {
                CarId = rental.CarId,
                CustomerName = rental.CustomerName,
                RentalStartDate = rental.RentalStartDate,
                RentalEndDate = rental.RentalEndDate
            };

            await _context.Rentals.AddAsync(newRental);
            await _context.SaveChangesAsync();

            return newRental;
        }

        public async Task<Rental> UpdateRentalEndDateAsync(int id, DateTime newEndDate)
        {
            var rental = await _context.Rentals.FindAsync(id);

            if (rental == null)
            {
                throw new KeyNotFoundException($"Rental with ID {id} not found.");
            }

            if (newEndDate <= rental.RentalStartDate)
            {
                throw new ArgumentException("Rental end date must be after the start date.");
            }

            rental.RentalEndDate = newEndDate;
            await _context.SaveChangesAsync();

            return rental;
        }

        public async Task<bool> DeleteRentalAsync(int id)
        {
            var rental = await _context.Rentals.FirstOrDefaultAsync(c => c.Id == id);
            if (rental == null)
            {
                return false;
            }

            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
