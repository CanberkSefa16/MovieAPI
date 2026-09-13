using MovieAPI.Data.Entities;

namespace MovieAPI.Data.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync(string? search, string? director, decimal? minRating, string? sortBy, bool descending, int page, int pageSize);
        Task<Movie?> GetByIdAsync(int id);
        Task AddAsync(Movie movie);
        void Delete(Movie movie);
        Task SaveChangesAsync();
        Task<int> CountAsync(string? search, string? director, decimal? minRating);
    }
}