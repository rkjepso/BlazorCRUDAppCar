namespace BlazorCRUDApp.Client.Services;

using Blazored.LocalStorage;
using System.Net.Http.Json;
using System.Text.Json;

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
        //var response = await LocalStorage.PostAsJsonAsync("api/Car", @car);
        //CarViewModel personResponse = await response.Content.ReadFromJsonAsync<CarViewModel>();
        await Load();
        List.Add(car);
        car.Id = List.Select(p => p.Id).Max() + 1;
        await Save();
        return car;
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<CarViewModel> GetPersonById(string Id)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        //var car = await LocalStorage.GetFromJsonAsync<CarViewModel>("api/car/" + Id);
 
        var car = List.FirstOrDefault(x => x.Id.ToString() == Id);
#pragma warning disable CS8603 // Possible null reference return.
        return car;
#pragma warning restore CS8603 // Possible null reference return.
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
#pragma warning restore CS8601 // Possible null reference assignment.
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
}

