
using System.Net.Http.Json;

namespace BlazorCRUDApp.Client.Services;

#pragma warning disable CS8600, CS8603 // Converting null literal or possible null value to non-nullable type.



public class WebService : IWebService
{
    HttpClient Http;
    public WebService(HttpClient httpClient) 
    {
        Http = httpClient;
    }

    public async Task<CarViewModel> Add(CarViewModel car)
    {
        var response = await Http.PostAsJsonAsync("api/Car", @car);
        CarViewModel personResponse = await response.Content.ReadFromJsonAsync<CarViewModel>();
        return personResponse;
    }

    public async Task<CarViewModel> GetPersonById(string Id)
    {
        var car = await Http.GetFromJsonAsync<CarViewModel>("api/car/" + Id);
        return car;
    }

    public async Task<List<CarViewModel>> GetAllCars()
    {
        var response = await Http.GetAsync("api/car");
        if (!response.IsSuccessStatusCode)
            return new List<CarViewModel>();
        var carlist = await response.Content.ReadFromJsonAsync<List<CarViewModel>>();
        return carlist;
    }

    public async Task<bool> UpdateCar(CarViewModel car)
    {
        var response = await Http.PutAsJsonAsync("api/Car/" + car.Id, @car);
        if (!response.IsSuccessStatusCode)
            return false;
        bool b = await response.Content.ReadFromJsonAsync<bool>();
        return b;
    }
    public async Task<bool> DeleteById(string Id)
    {
        var response = await Http.DeleteAsync("api/Car/" + Id);
        if (!response.IsSuccessStatusCode)
            return false;
        bool deleteResponse = await response.Content.ReadFromJsonAsync<bool>();
        return deleteResponse;
    }
}

#pragma warning restore CS8600, CS8603 // Converting null literal or possible null value to non-nullable type.

