using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Service.DTOs
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(20)]
        public required string Name { get; set; }
    }
}