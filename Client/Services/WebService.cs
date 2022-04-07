
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
        try
        {
            var car = await Http.GetFromJsonAsync<CarViewModel>("api/car/" + Id);
            return car;
        }
        catch (Exception )
        {  
        }
        return null;
    }

    public async Task<List<CarViewModel>> GetAllCars()
    {
        CarViewModel error = new CarViewModel();
        var list = new List<CarViewModel>();
        try
        {
            var carlist = await Http.GetFromJsonAsync<List<CarViewModel>>("api/Car/GetAll");
            return carlist;
        }
        catch (Exception e)
        {
            error.Brand = e.Message;
            error.Model = e.HResult.ToString();
        }
        list.Add(error);
        return list;
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

