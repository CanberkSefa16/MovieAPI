using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set;}
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}