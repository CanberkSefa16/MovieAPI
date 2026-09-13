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
        public async Task<IActionResult> GetMovies([FromQuery] string? search, [FromQuery] string? director, [FromQuery] decimal? minRating,
        [FromQuery] string? sortBy, [FromQuery] bool descending, [FromQuery] int page=1, [FromQuery] int pageSize=10)
        {
            if(page < 1)
                return BadRequest("Page must be greater than 0.");
            
            if(pageSize < 1 || pageSize > 100)
                return BadRequest("Page size must be between 1 and 100.");

            PageResult<MovieDto> result = await _movieService.GetAllMoviesAsync(search, director, minRating, sortBy, descending, page, pageSize);
            return Ok(result);
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
            MovieDto dto = await _movieService.AddMovieAsync(movieDto);
            
            return CreatedAtAction(
                nameof(GetMovieById),
                new { id = dto.Id },
                dto
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