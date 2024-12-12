using CarRentalAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Repository
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
    }
}
