namespace MovieAPI.Service.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MovieId { get; set; }
        public required string Username { get; set; }
        public required string MovieTitle { get; set; }
    }
}