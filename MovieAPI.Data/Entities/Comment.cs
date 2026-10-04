namespace MovieAPI.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public required User User { get; set; }

        public int MovieId { get; set; }
        public required Movie Movie { get; set;}
    }
}