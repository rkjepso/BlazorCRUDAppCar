using BlazorCRUDApp.Server.Models;

namespace BlazorCRUDApp.Server.Services
{
    public interface ICarService
    {
        Task<Car> AddCar(Car car);

        Task<bool> UpdateCar(int id, Car car);

        Task<bool> DeleteCar(int id);

        Task<List<Car>> GetAllCars();

        Task<Car> GetCar(int id);

    }
}
