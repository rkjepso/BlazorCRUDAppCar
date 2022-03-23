using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUDApp.Client;

public record CarViewModel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Brand")]
    public string Brand { get; set; } = "";

    [Required]
    [Display(Name = "Model")]
    public string Model { get; set; } = "";

    [Display(Name = "Year")]
    public int Year { get; set; } = 1970;

    [Display(Name = "Mobile Number")]
    public int  Price { get; set; } = 0;


    public static CarViewModel CreateRandomCar()
    {
        string[] f = { "Volvo", "Volvo", "Ferrari", "Porche", "Jaguar" };
        string[] l = { "Amazon", "PV", "512", "911", "EType" };
        (int, int)[] yr = { (1965, 1970), (1949, 1965), (1980, 1990), (1950, 2011), (1965, 1970) };
        (int, int)[] p = { (100, 200), (20, 250), (700, 3000), (500, 3500), (400, 2000) };

        CarViewModel car = new();
        Random r = new();

        int i = r.Next(0, f.Length);
        car.Brand = f[i];
        car.Model = l[i];
        car.Year = r.Next(yr[i].Item1, yr[i].Item2);
        car.Price = r.Next(p[i].Item1, p[i].Item2) * 1000;

        return car;
    }
}   

