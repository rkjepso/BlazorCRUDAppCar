namespace BlazorCRUDApp.Client.Services;

using Blazored.LocalStorage;
using System.Net.Http.Json;
using System.Text.Json;

#pragma warning disable CS8603, CS8601, CS1998 // Possible null reference return.

public class LocalService : IServiceLocal
{
    ILocalStorageService LocalStorage;
    static  List<CarViewModel> List=new();
    public LocalService(ILocalStorageService localStorage)
    {
        LocalStorage = localStorage;
    }

    public async Task<CarViewModel> Add(CarViewModel car)
    {
        await Load();
        List.Add(car);
        car.Id = Math.Max(IWebService.ID_LOCAL, List.Select(p => p.Id).Max() + 1); // Trick to avoid
        await Save();
        return car;
    }


    public async Task<CarViewModel> GetPersonById(string Id)
    {
        var car = List.FirstOrDefault(x => x.Id.ToString() == Id);

        return car;

    }

    public async Task<List<CarViewModel>> GetAllCars()
    {
        await Load();
        return List;
    }

    public async Task<bool> UpdateCar(CarViewModel car)
    {
        await Load();
        int idx = List.FindIndex(p => p.Id == car.Id);
        if (idx < 0) 
            return false;
  
        List[idx] = car;

        await Save();
        return true;
    }
    public async Task<bool> DeleteById(string Id)
    {
        await Load();

        bool deleteResponse = true;
        var car = List.FirstOrDefault(x => x.Id.ToString() == Id);
        if (car != null)
            List.Remove(car);

        await Save();
        return deleteResponse;
    }

    private async Task<bool> Load()
    {
        string str;
        try
        {
            str = await LocalStorage.GetItemAsStringAsync("db");
#pragma warning disable CS8601 // Possible null reference assignment.
            List = JsonSerializer.Deserialize<List<CarViewModel>>(str);

        }
        catch (Exception)
        {
            return false;
        }
        return List?.Count > 0;
    }

    private async Task<bool> Save()
    {
        string str = JsonSerializer.Serialize<List<CarViewModel>>(List);
        await LocalStorage.SetItemAsStringAsync("db", str);
        return true;
    }

    public async Task<List<CarViewModel>> Sync(List<CarViewModel> listServer)
    {
        List.Clear();
        List = listServer;
        await Save();
        return List;
    }
}

