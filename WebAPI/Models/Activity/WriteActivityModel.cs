using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.ActivityDtos
{
    public class WriteActivityModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
