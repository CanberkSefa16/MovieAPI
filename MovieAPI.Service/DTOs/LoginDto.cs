using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Service.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}