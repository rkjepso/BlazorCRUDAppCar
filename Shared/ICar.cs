using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUDApp.Shared;

public interface ICar
{
    public int Id       { get; set; }
    public string Brand { get; set; } 
    public string Model { get; set; } 
    public int Year     { get; set; }
    public int Price    { get; set; }
}   

