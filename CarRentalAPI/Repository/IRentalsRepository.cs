using CarRentalAPI.Entities;

namespace CarRentalAPI.Repository
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetRentalsAsync();
        Task<Rental> CreateRentalAsync(Rental rental);
        Task<Rental> UpdateRentalEndDateAsync(int id, DateTime newEndDate);
        Task<bool> DeleteRentalAsync(int id);
    }
}