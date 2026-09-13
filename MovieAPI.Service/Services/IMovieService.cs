using MovieAPI.Data.Entities;
using MovieAPI.Service.DTOs;

namespace MovieAPI.Service.Services
{
    public interface IMovieService
    {
        Task<PageResult<MovieDto>> GetAllMoviesAsync(string? search, string? director, decimal? minRating, string? sortBy, bool descending, int page, int pageSize);
        Task<MovieDto?> GetMovieByIdAsync(int id);
        Task<MovieDto> AddMovieAsync(CreateMovieDto movieDto);
        Task<bool> UpdateMovieAsync(UpdateMovieDto movieDto, int id);
        Task<bool> DeleteMovieAsync(int id);
    }
}