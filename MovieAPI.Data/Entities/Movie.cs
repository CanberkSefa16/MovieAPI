using System;

namespace MovieAPI.Data.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Director { get; set; }
        public required DateOnly ReleaseDate { get; set; }
        public required int DurationMinutes { get; set; }
        public decimal Rating { get; set; }
        public string? PosterUrl { get; set; }
        
    }
}