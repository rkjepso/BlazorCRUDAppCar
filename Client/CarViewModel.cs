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
    public string Year { get; set; } = "";

    [Display(Name = "Mobile Number")]
    public string Price { get; set; } = "";
}   

