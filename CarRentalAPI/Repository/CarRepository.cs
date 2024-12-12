using CarRentalAPI.Data;
using CarRentalAPI.Entities;
using Microsoft.AspNetCore.Mvc;
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

            existingCar.Brand = car.Brand;
            existingCar.Model = car.Model;
            existingCar.VinNumber = car.VinNumber;

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


    }
}
