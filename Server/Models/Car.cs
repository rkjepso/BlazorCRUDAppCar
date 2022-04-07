using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorCRUDApp.Shared;
namespace BlazorCRUDApp.Server.Models
{
    [Table("Car", Schema ="dbo")]
    public record Car : ICar
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required] 
        public string Brand { get; set; } ="";
        
        [Required] 
        public string Model { get; set; } ="";

        public int Year { get;set; }
        
        public int Price { get; set; }
    }
}
