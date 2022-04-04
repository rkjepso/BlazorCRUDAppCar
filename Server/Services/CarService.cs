using BlazorCRUDApp.Server.Models;
using BlazorCRUDApp.Server.Repository;

namespace BlazorCRUDApp.Server.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _car;
        public CarService(IRepository<Car> car)
        {
            _car = car;
        }
        public async Task<Car> AddCar(Car car)
        {
            return await _car.CreateAsync(car);
        }

        public async Task<bool> UpdateCar(int id, Car car) 
        {
            var data = await _car.GetByIdAsync(id);

            if (data == null)
                return false;  
            data = car;
            await _car.UpdateAsync(data);
            return true;
        }

        public async Task<bool> DeleteCar(int id)
        {
            await _car.DeleteAsync(id);
            return true;
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await _car.GetAllAsync();
        }

        public async Task<Car> GetCar(int id)
        {
            return await _car.GetByIdAsync(id);
        }
    }
}
