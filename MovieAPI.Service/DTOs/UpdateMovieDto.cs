using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Service.DTOs
{
    public class UpdateMovieDto
    {
        [Required]
        [MaxLength(50)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public required string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Director { get; set; }

        public DateOnly ReleaseDate { get; set; }

        [Range(1,240)]
        public int DurationMinutes { get; set; }

        [Url]
        public string? PosterUrl { get; set; }
        
    }
}