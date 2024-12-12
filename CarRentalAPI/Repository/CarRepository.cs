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
    }
}
