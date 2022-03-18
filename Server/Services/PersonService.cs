using BlazorCRUDApp.Server.Models;
using BlazorCRUDApp.Server.Repository;

namespace BlazorCRUDApp.Server.Services
{
    public class PersonService : ICarService
    {
        private readonly IRepository<Car> _person;
        public PersonService(IRepository<Car> car)
        {
            _person = car;
        }
        public async Task<Car> AddCar(Car car)
        {
            return await _person.CreateAsync(car);
        }

        public async Task<bool> UpdateCar(int id, Car car) 
        {
            var data = await _person.GetByIdAsync(id);

            if (data != null)
            {  
                data.Brand = car.Brand;
                data.Model = car.Model;
                data.Year = car.Year;
                data.Price = car.Price;

                await _person.UpdateAsync(data);
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteCar(int id)
        {
            await _person.DeleteAsync(id);
            return true;
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await _person.GetAllAsync();
        }

        public async Task<Car> GetCar(int id)
        {
            return await _person.GetByIdAsync(id);
        }
    }
}
