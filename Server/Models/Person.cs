using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCRUDApp.Server.Models
{
    [Table("Person", Schema ="dbo")]
    public record Person
    {
       [Required]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required] 
        public string? FirstName { get; set; }
        
        [Required] 
        public string? LastName { get; set; }
        
        public string? Email { get;set; }
        
        public string? MobileNo { get; set; }
    }
}
