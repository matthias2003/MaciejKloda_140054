using CarRentalAPI.Entities;

namespace CarRentalAPI.Repository
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task<Car> CreateCarAsync(Car car);
        Task<Car> UpdateCarAsync(int id, Car car);
        Task<bool> DeleteCarAsync(int id);
        Task<IEnumerable<Car>> GetAvailableCarsAsync();
    }
}
