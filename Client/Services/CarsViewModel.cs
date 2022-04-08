using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BlazorCRUDApp.Shared;

namespace BlazorCRUDApp.Client;
#pragma warning disable CS8604, CS8600 // Possible null reference argument.
public class CarsViewModel : ICarsViewModel
{
    //properties
    public List<CarViewModel> Lst { get; set; } = new ();
    private HttpClient _httpClient;
    private bool DemoMode = true;
    //methods
    public CarsViewModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task RefreshVM()
   {
        Lst.Clear();
        List<Car> cars = null;
        if (DemoMode)
            cars = ModelFake.Lst;
        else
            cars = await _httpClient.GetFromJsonAsync<List<Car>>("api/Car/GetAll");
        foreach (var car in cars ?? new List<Car>())
        {
            Lst.Add((CarViewModel)car);
        }
    }
    public async Task<CarViewModel> Add(CarViewModel car)
    {
        if (DemoMode)
            car = (CarViewModel)ModelFake.Add((Car)car);
        else
        {
            var response = await _httpClient.PostAsJsonAsync("api/Car", @car);
            car = (CarViewModel)await response.Content.ReadFromJsonAsync<Car>();
        }
        return car;
    }
    public async Task<CarViewModel> GetById(string Id)
    {       
        try
        {
            if (DemoMode)
                return (CarViewModel)ModelFake.Lst.Find(x => x.Id.ToString() == Id);
            var car = await _httpClient.GetFromJsonAsync<Car>("api/car/" + Id);
            return (CarViewModel)car;

        }
        catch (Exception)
        {
        }
        return null;
    }

    public async Task<bool> Update(CarViewModel carVM)
    {
        bool b = false;
        if (DemoMode)
        {
            b = ModelFake.Update((Car)carVM);
        }
        else
        {
            Car car = (Car)carVM;
            var response = await _httpClient.PutAsJsonAsync("api/Car/" + car.Id, @car);
            if (!response.IsSuccessStatusCode)
                return false;
            b = await response.Content.ReadFromJsonAsync<bool>();
        }
        await RefreshVM();
        return b;
    }

    public async Task<bool> DeleteById(string Id)
    {
        bool bOk;
        if (DemoMode)
            bOk = ModelFake.DeleteById(int.Parse(Id));
        else
        {
            var response = await _httpClient.DeleteAsync("api/Car/" + Id);
            if (!response.IsSuccessStatusCode)
                return false;
            bOk = await response.Content.ReadFromJsonAsync<bool>();
        }
        await RefreshVM();
        return bOk;
    }

}

