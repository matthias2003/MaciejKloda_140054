using CarRentalAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalAPI.Repository;
using CarRentalAPI.Entities;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public RentalsController(DataContext context)
        {
            _dataContext = context;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            var rentals = await _dataContext.Rentals
                .Include(r => r.Car) 
                .ToListAsync();

            return Ok(rentals);
        }
        [HttpPost]
        public async Task<ActionResult<Rental>> CreateRental([FromBody] Rental rental)
        {
            // Sprawdzamy, czy dane wypożyczenia są poprawne
            if (rental == null || rental.CarId == 0 || string.IsNullOrEmpty(rental.CustomerName) ||
                rental.RentalStartDate == DateTime.MinValue || rental.RentalEndDate == DateTime.MinValue)
            {
                return BadRequest("Invalid rental data.");
            }

            // Sprawdzamy, czy samochód o podanym CarId istnieje
            var car = await _dataContext.Car.FindAsync(rental.CarId);
            if (car == null)
            {
                return NotFound($"Car with ID {rental.CarId} not found.");
            }

            // Tworzymy nowe wypożyczenie
            var newRental = new Rental
            {
                CarId = rental.CarId, // Używamy CarId z obiektu Rental
                CustomerName = rental.CustomerName,
                RentalStartDate = rental.RentalStartDate,
                RentalEndDate = rental.RentalEndDate
                // Car nie jest przechowywane, ponieważ jest to tylko klucz obcy
            };

            // Dodajemy wypożyczenie do bazy
            _dataContext.Rentals.Add(newRental);
            await _dataContext.SaveChangesAsync();

            // Zwracamy odpowiedź z nowym wypożyczeniem
            return CreatedAtAction(nameof(GetRentals), new { id = newRental.Id }, newRental);
        }
    }
}
