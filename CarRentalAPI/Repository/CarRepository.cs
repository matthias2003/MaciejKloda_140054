using CarRentalAPI.Data;
using CarRentalAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _dataContext;
        public CarRepository(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _dataContext.Car.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _dataContext.Car.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            _dataContext.Car.Add(car);
            await _dataContext.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateCarAsync(int id, Car car)
        {
            var existingCar = await _dataContext.Car.FirstOrDefaultAsync(c => c.Id == id);
            
            if (existingCar == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(car.Brand))
            {
                existingCar.Brand = car.Brand;
            }

            if (!string.IsNullOrEmpty(car.Model))
            {
                existingCar.Model = car.Model;
            }

            if (!string.IsNullOrEmpty(car.VinNumber))
            {
                existingCar.VinNumber = car.VinNumber;
            }


            await _dataContext.SaveChangesAsync();
            return existingCar;
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var car = await _dataContext.Car.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                return false;
            }

            _dataContext.Car.Remove(car);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Car>> GetAvailableCarsAsync()
        {
            var availableCars = await _dataContext.Car
                .Where(car => !_dataContext.Rentals
                .Any(rental => rental.CarId == car.Id))
                .ToListAsync();

            return availableCars;
        }
    }
}
