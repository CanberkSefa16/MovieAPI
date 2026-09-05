using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data.Entities;
using MovieAPI.Service.DTOs;
using MovieAPI.Service.Services;

namespace MovieAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            List<MovieDto> movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            MovieDto? movie = await _movieService.GetMovieByIdAsync(id);

            if(movie != null)
                return Ok(movie);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = await _movieService.AddMovieAsync(movieDto);
            
            return CreatedAtAction(
                nameof(GetMovieById),
                new { id = movie.Id },
                movie
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieDto movieDto, int id)
        {
            bool updated = await _movieService.UpdateMovieAsync(movieDto, id);

            if(!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            bool deleted = await _movieService.DeleteMovieAsync(id);
            
            if(!deleted)
                return NotFound();

            return NoContent();
        }

    }
}