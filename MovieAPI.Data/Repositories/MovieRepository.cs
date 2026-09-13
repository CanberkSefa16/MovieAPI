using Microsoft.EntityFrameworkCore;
using MovieAPI.Data.Context;
using MovieAPI.Data.Entities;

namespace MovieAPI.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
        }

        public void Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
        }

        public async Task<List<Movie>> GetAllAsync(string? search, string? director, decimal? minRating, string? sortBy, bool descending, int page, int pageSize)
        {
            var query = _context.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where( x => x.Title.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(director))
            {
                query = query.Where( x => x.Director.Contains(director));
            }

            if(minRating != null)
            {
                query = query.Where(x => x.Rating >= minRating);
            }

            switch (sortBy?.ToLower())
            {
                case "title":
                    if(descending)
                        query = query.OrderByDescending(x => x.Title);
                    else
                        query = query.OrderBy(x => x.Title);
                    break;
                
                case "rating":
                    if(descending)
                        query = query.OrderByDescending(x => x.Rating);
                    else
                        query = query.OrderBy(x => x.Rating);
                    break;
                
                case "releasedate":
                    if(descending)
                        query = query.OrderByDescending(x => x.ReleaseDate);
                    else
                        query = query.OrderBy(x => x.ReleaseDate);
                    break;
                
                default:
                    query = query.OrderBy(x => x.Id);
                    break;
                    
            }

            query = query
                .Skip((page-1) * pageSize)
                .Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync(string? search, string? director, decimal? minRating)
        {
            var query = _context.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Title.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(director))
            {
                query = query.Where(x => x.Director.Contains(director));
            }

            if (minRating.HasValue)
            {
                query = query.Where(x => x.Rating >= minRating.Value);
            }

            return await query.CountAsync();
        }
    }
}