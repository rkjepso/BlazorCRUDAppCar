using BlazorCRUDApp.Server.Models;
using BlazorCRUDApp.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUDApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService personService)
        {
            _carService = personService;
        }

        [HttpGet]
        public async Task<List<Car>> GetAll()
        {
            return await _carService.GetAllCars();
        }

        [HttpGet("{id}")]
        public async Task<Car> Get(int id)
        {
            return await _carService.GetCar(id);
        }

        [HttpPost]
        public async Task<Car> AddCar([FromBody] Car car)
        {
           return await _carService.AddCar(car);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCar(int id)
        {
            await _carService.DeleteCar(id); return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateCar(int id, [FromBody] Car Object)
        {
            await _carService.UpdateCar(id, Object); return true;
        }
    }
}
