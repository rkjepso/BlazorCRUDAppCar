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
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task RefreshVM()
   {
        Lst.Clear ();
        var cars = ModelFake.Lst;

        //if (_httpClient == null)
        //    return;
        //var cars = await _httpClient.GetFromJsonAsync<List<Car>>("api/Car/RefreshVM");
        //if (cars == null)
        //    return;
        foreach (var car in cars ?? new List<Car>())
        {
            CarViewModel carViewModel = car;
            Lst.Add(carViewModel);
        }
    }
    public async Task<CarViewModel> Add(CarViewModel car)
    {
        car = ModelFake.Add(car);
//        var response = await _httpClient.PostAsJsonAsync("api/Car", @car);
//        CarViewModel? personResponse = await response.Content.ReadFromJsonAsync<CarViewModel>();
//#pragma warning disable CS8603 // Possible null reference return.
//        return personResponse;
        return car;
    }
    public async Task<CarViewModel> GetById(string Id)
    {
        return ModelFake.Lst.Find (x => x.Id.ToString() == Id);
        //try
        //{
        //    var car = await _httpClient.GetFromJsonAsync<CarViewModel>("api/car/" + Id);
        //    return car;

        //}
        //catch (Exception)
        //{
        //}
        //return null;
    }

    public async Task<bool> Update(CarViewModel carVM)
    {
        ModelFake.Update(carVM); 
        RefreshVM();
        return true;

        //Car car = carVM;
        //var response = await _httpClient.PutAsJsonAsync("api/Car/" + car.Id, @car);
        //if (!response.IsSuccessStatusCode)
        //    return false;

        //bool b = await response.Content.ReadFromJsonAsync<bool>();
        //return b;
    }

    public async Task<bool> DeleteById(string Id)
    {
        ModelFake.DeleteById(int.Parse(Id));
        RefreshVM();
        return true;
        //var response = await _httpClient.DeleteAsync("api/Car/" + Id);
        //if (!response.IsSuccessStatusCode)
        //    return false;
        //bool deleteResponse = await response.Content.ReadFromJsonAsync<bool>();
        //return deleteResponse;
    }
#pragma warning restore CS8603 // Possible null reference return.
}

