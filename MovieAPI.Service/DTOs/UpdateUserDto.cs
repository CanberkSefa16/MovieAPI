using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Service.DTOs
{
    public class UpdateUserDto
    {
        [Required]
        [MaxLength(30)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public required string Surname { get; set; }

        [Required]
        [MaxLength(30)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public required string Email { get; set; }
    }
}