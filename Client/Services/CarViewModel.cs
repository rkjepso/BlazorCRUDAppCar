using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorCRUDApp.Shared;


namespace BlazorCRUDApp.Client;

public record Car : ICar
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Price { get; set; }
}

public record CarViewModel : ICar
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; } = 1970;
    public int  Price { get; set; } = 0;

    public static explicit operator CarViewModel(Car obj)
    {
        return new CarViewModel
        {
            Id = obj.Id,
            Brand = obj.Brand,
            Model = obj.Model,
            Year = obj.Year,
            Price = obj.Price,    
        };
    }
    public static explicit operator Car(CarViewModel obj)
    {
        return new Car
        {
            Id = obj.Id,
            Brand = obj.Brand,
            Model = obj.Model,
            Year = obj.Year,
            Price = obj.Price,
        };
    }


    public static CarViewModel CreateRandomCar()
    {
        string[] b = { "Volvo", "Volvo", "Ferrari", "Porche", "Jaguar" };
        string[] m = { "Amazon", "PV", "512", "911", "EType" };
        (int, int)[] yr = { (1965, 1970), (1949, 1965), (1980, 1990), (1950, 2011), (1965, 1970) };
        (int, int)[] p = { (100, 200), (20, 250), (700, 3000), (500, 3500), (400, 2000) };
        
        Debug.Assert((b.Length, b.Length, b.Length)==(m.Length, yr.Length, p.Length), "Error Length");

        CarViewModel car = new();
        Random r = new();

        int i = r.Next(0, b.Length);
        car.Brand = b[i];
        car.Model = m[i];
        car.Year = r.Next(yr[i].Item1, yr[i].Item2);
        car.Price = r.Next(p[i].Item1, p[i].Item2) * 1000;

        return car;
    }

    public static string GetImg(CarViewModel? car)
    {
        if (car== null)
            return "";
        return (car.Brand, car.Model) switch
        {
            ("Volvo", "Amazon") => "Img/VolvoAmazon.jpg",
            ("Volvo", "PV") => "Img/VolvoPV.jpg",
            ("Ferrari", "512") => "Img/Ferrari512.jpg",
            ("Porche", "911") => "Img/Porche911.jpg",
            ("Jaguar", "EType") => "Img/JaguarEType.jpg",
            _ => "Img/dummy.jpg"
        };
    }
}   

