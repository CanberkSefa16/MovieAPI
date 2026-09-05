using MovieAPI.Data.Entities;

namespace MovieAPI.Data.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task AddAsync(Movie movie);
        void Delete(Movie movie);
        Task SaveChangesAsync();
    }
}