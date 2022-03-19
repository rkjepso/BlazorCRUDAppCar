namespace BlazorCRUDApp.Client.Services;

using Blazored.LocalStorage;
using System.Net.Http.Json;


public class LocalService : IWebService
{
    ILocalStorageService LocalStorage;
    static readonly List<CarViewModel>? List=new();
    public LocalService(ILocalStorageService localStorage)
    {
        LocalStorage = localStorage;
        Load();
    }

    public async Task<CarViewModel> Add(CarViewModel car)
    {
        //var response = await LocalStorage.PostAsJsonAsync("api/Car", @car);
        //CarViewModel personResponse = await response.Content.ReadFromJsonAsync<CarViewModel>();
        List.Add(car);
        car.Id = List.Select(p => p.Id).Max() + 1;
        await Save();
        return car;
    }

    public async Task<CarViewModel> GetPersonById(string Id)
    {
        //var car = await LocalStorage.GetFromJsonAsync<CarViewModel>("api/car/" + Id);
 
        var car = List.FirstOrDefault(x => x.Id.ToString() == Id);
        return car;
    }

    public async Task<List<CarViewModel>> GetAllCars()
    {
        //var response = await LocalStorage.GetAsync("api/car");
        //if (!response.IsSuccessStatusCode)
        //    return new List<CarViewModel>();
        //var carlist = await response.Content.ReadFromJsonAsync<List<CarViewModel>>();
        return List;
    }

    public async Task<bool> UpdateCar(CarViewModel car)
    {
        //var response = await LocalStorage.PutAsJsonAsync("api/Car/" + car.Id, @car);
        //if (!response.IsSuccessStatusCode)
        //    return false;
        //bool b = await response.Content.ReadFromJsonAsync<bool>();
        int idx = List.FindIndex(p => p.Id == car.Id);
        if (idx < 0) 
            return false;
  
        List[idx] = car;

        await Save();
        return true;
    }
    public async Task<bool> DeleteById(string Id)
    {
        //var response = await LocalStorage.DeleteAsync("api/Car/" + Id);
        //if (!response.IsSuccessStatusCode)
        //    return false;
        //bool deleteResponse = await response.Content.ReadFromJsonAsync<bool>();
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
        }
        catch (Exception)
        {

            return false;
        }
        
        return str.Length > 0;
    }

    private async Task<bool> Save()
    {
        string str = "";
        await LocalStorage.SetItemAsStringAsync("db", str);
        return true;
    }
}

