using MovieAPI.Data.Entities;

namespace MovieAPI.Service.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetMovieByIdAsync(int id);
        Task AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(int id);
    }
}