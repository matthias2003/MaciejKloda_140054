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
      
        // GET: api/rentals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            var rentals = await _dataContext.Rentals
                .Include(r => r.Car)  // Jeśli chcesz pobrać również dane powiązanych samochodów
                .ToListAsync();

            return Ok(rentals); // Zwróci dane jako JSON
        }
    }
}
