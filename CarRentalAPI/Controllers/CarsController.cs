using CarRentalAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalAPI.Repository;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carRepository.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
    }
}