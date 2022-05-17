using System.ComponentModel.DataAnnotations;
namespace PlatformService.Models
{
    public class Contacts
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Number { get; set; }        
    }
}
