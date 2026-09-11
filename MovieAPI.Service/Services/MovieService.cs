
using System.Runtime.InteropServices;
using MovieAPI.Data.Entities;
using MovieAPI.Data.Repositories;
using MovieAPI.Service.DTOs;

namespace MovieAPI.Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;    
        }


        public async Task<MovieDto> AddMovieAsync(CreateMovieDto movieDto)
        {
            Movie movie = new Movie
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                Director = movieDto.Director,
                ReleaseDate = movieDto.ReleaseDate,
                DurationMinutes = movieDto.DurationMinutes,
                PosterUrl = movieDto.PosterUrl
            };

            await _movieRepository.AddAsync(movie);
            await _movieRepository.SaveChangesAsync();

            MovieDto dto = new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Director = movie.Director,
                DurationMinutes = movie.DurationMinutes,
                ReleaseDate = movie.ReleaseDate,
                Rating = movie.Rating,
                PosterUrl = movie.PosterUrl
            };

            return dto;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var existed_movie = await _movieRepository.GetByIdAsync(id);

            if(existed_movie == null)
                return false;
            
            _movieRepository.Delete(existed_movie);
            await _movieRepository.SaveChangesAsync();

            return true;
        }

        public async Task<List<MovieDto>> GetAllMoviesAsync()
        {
            List<MovieDto> movies = new List<MovieDto>();

            List<Movie> records = await _movieRepository.GetAllAsync();

            for(int i=0; i<records.Count; i++)
            {
                MovieDto dto = new MovieDto
                {
                    Id              = records[i].Id,
                    Title           = records[i].Title,
                    Description     = records[i].Description,
                    Director        = records[i].Director,
                    ReleaseDate     = records[i].ReleaseDate,
                    DurationMinutes = records[i].DurationMinutes,
                    Rating          = records[i].Rating,
                    PosterUrl       = records[i].PosterUrl

                };

                movies.Add(dto);
            }

            return movies;
        }

        public async Task<MovieDto?> GetMovieByIdAsync(int id)
        {
            Movie? movie = await _movieRepository.GetByIdAsync(id);

            if(movie == null)
                return null;
            
            MovieDto dto = new MovieDto
            {
                Id              = movie.Id,
                Title           = movie.Title,
                Description     = movie.Description,
                Director        = movie.Director,
                ReleaseDate     = movie.ReleaseDate,
                DurationMinutes = movie.DurationMinutes,
                Rating          = movie.Rating,
                PosterUrl       = movie.PosterUrl
            };

            return dto;
        }

        public async Task<bool> UpdateMovieAsync(UpdateMovieDto movieDto, int id)
        {
            var existed = await _movieRepository.GetByIdAsync(id);
            
            if(existed == null)
                return false;

            existed.Title = movieDto.Title;
            existed.Director = movieDto.Director;
            existed.ReleaseDate = movieDto.ReleaseDate;
            existed.DurationMinutes = movieDto.DurationMinutes;
            existed.PosterUrl = movieDto.PosterUrl;

            await _movieRepository.SaveChangesAsync();

            return true;
        }
    }
}