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

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
        }
    }
}