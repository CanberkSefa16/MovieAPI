namespace MovieAPI.Service.DTOs
{
    public class UpdateMovieDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Director { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int DurationMinutes { get; set; }
        public string? PosterUrl { get; set; }
        
    }
}