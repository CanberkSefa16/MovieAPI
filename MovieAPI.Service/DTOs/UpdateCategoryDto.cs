using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Service.DTOs
{
    public class UpdateCategoryDto
    {
        [Required]
        [MaxLength(20)]
        public required string Name { get; set; }
    }
}