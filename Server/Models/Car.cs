using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCRUDApp.Server.Models
{
    [Table("Car", Schema ="dbo")]
    public record Car
    {
       [Required]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required] 
        public string? Brand { get; set; }
        
        [Required] 
        public string? Model { get; set; }

        public int? Year { get;set; }
        
        public int? Price { get; set; }
    }
}
