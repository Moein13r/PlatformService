using System.ComponentModel.DataAnnotations;

namespace PlatformService.DTOs
{
    public class ContactsCreateDTo
    {                   
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Number { get; set; }
    }
}