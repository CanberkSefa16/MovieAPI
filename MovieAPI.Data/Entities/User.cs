using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public required string Name { get; set; }

        [MaxLength(30)]
        public required string Surname { get; set; }

        [MaxLength(30)]
        public required string Username { get; set; }

        [MaxLength(100)]
        public required string Email { get; set; }
        
        public required string PasswordHash { get; set; }
    }
}