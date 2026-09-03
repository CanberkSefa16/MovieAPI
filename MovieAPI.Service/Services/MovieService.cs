
using MovieAPI.Data.Entities;
using MovieAPI.Data.Repositories;

namespace MovieAPI.Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;    
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _movieRepository.AddAsync(movie);
            await _movieRepository.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var existed_movie = await _movieRepository.GetByIdAsync(movie.Id);

            if(existed_movie == null)
                return;
            
            _movieRepository.Delete(existed_movie);
            await _movieRepository.SaveChangesAsync();
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            var existed = await _movieRepository.GetByIdAsync(movie.Id);
            
            if(existed == null)
                return;

            existed.Title = movie.Title;
            existed.Director = movie.Director;
            existed.ReleaseDate = movie.ReleaseDate;
            existed.DurationMinutes = movie.DurationMinutes;
            existed.PosterUrl = movie.PosterUrl;

            await _movieRepository.SaveChangesAsync();
        }
    }
}