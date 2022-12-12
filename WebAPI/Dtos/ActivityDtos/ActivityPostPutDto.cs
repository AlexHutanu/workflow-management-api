using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos.ActivityDtos
{
    public class ActivityPostPutDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
