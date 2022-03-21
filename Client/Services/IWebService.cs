

namespace BlazorCRUDApp.Client.Services;
public interface IWebService
{
    Task<CarViewModel> Add(CarViewModel p);
    Task<List<CarViewModel>> GetAllCars();
    Task<CarViewModel> GetPersonById(string id);
    Task<bool> UpdateCar(CarViewModel car);
    Task<bool> DeleteById(string id);
    Task<List<CarViewModel>> Sync(List<CarViewModel> list);

    public const int ID_LOCAL = 1000000;
}

public interface IServiceLocal : IWebService
{
}
