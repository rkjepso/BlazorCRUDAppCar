using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BlazorCRUDApp.Shared;

namespace BlazorCRUDApp.Client;
public class CarsViewModel : ICarsViewModel
{
    //properties
    public List<CarViewModel> Lst { get; set; } = new ();
    private HttpClient _httpClient;

    //methods
    public CarsViewModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task GetAll()
    {
        if (_httpClient == null)
            return;
        var cars = await _httpClient.GetFromJsonAsync<List<Car>>("api/Car/GetAll");
        if (cars == null)
            return;
        foreach (var car in cars ?? new List<Car>())
        {
            CarViewModel carViewModel = car;
            Lst.Add(carViewModel);
        }
    }
    public async Task<CarViewModel?> Add(CarViewModel car)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Car", @car);
        CarViewModel? personResponse = await response.Content.ReadFromJsonAsync<CarViewModel>();
        return personResponse;
    }
    public async Task<CarViewModel> GetById(string Id)
    {
        try
        {
            var car = await _httpClient.GetFromJsonAsync<CarViewModel>("api/car/" + Id);
            return car;
        }
        catch (Exception)
        {
        }
        return null;
    }

    public async Task<bool> Update(CarViewModel carVM)
    {
        Car car = carVM;
        var response = await _httpClient.PutAsJsonAsync("api/Car/" + car.Id, @car);
        if (!response.IsSuccessStatusCode)
            return false;

        bool b = await response.Content.ReadFromJsonAsync<bool>();
        return b;
    }

    public async Task<bool> DeleteById(string Id)
    {
        var response = await _httpClient.DeleteAsync("api/Car/" + Id);
        if (!response.IsSuccessStatusCode)
            return false;
        bool deleteResponse = await response.Content.ReadFromJsonAsync<bool>();
        return deleteResponse;
    }
}

