namespace MovieAPI.Service.DTOs
{
    public class LoginResponseDto
    {
        public required string Token { get; set; }
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
    }
}