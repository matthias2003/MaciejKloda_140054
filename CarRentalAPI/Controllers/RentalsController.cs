using CarRentalAPI.Entities;
using CarRentalAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalRepository _rentalRepository;
        public RentalsController(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            var rentals = await _rentalRepository.GetRentalsAsync();
            return Ok(rentals);
        }

        [HttpPost]
        public async Task<ActionResult<Rental>> CreateRental([FromBody] Rental rental)
        {
            try
            {
                var newRental = await _rentalRepository.CreateRentalAsync(rental);
                return CreatedAtAction(nameof(GetRentals), new { id = newRental.Id }, newRental);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRental(int id)
        {
            var deleted = await _rentalRepository.DeleteRentalAsync(id);

            if (!deleted)
            {
                return NotFound($"Rental with ID {id} not found.");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Rental>> UpdateRentalEndDate(int id, [FromBody] DateTime newEndDate)
        {
            try
            {
                var updatedRental = await _rentalRepository.UpdateRentalEndDateAsync(id, newEndDate);
                return Ok(updatedRental);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
