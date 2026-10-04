using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Service.DTOs
{
    public class CreateCommentDto
    {
        [Required]
        [MaxLength(1000)]
        public required string Content { get; set; }
        
        public int MovieId { get; set; }

    }
}