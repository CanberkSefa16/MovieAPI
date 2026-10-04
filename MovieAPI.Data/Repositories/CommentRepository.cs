using Microsoft.EntityFrameworkCore;
using MovieAPI.Data.Context;
using MovieAPI.Data.Entities;

namespace MovieAPI.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }

        public void DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
        }

        public async Task<Comment?> GetCommentByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<ICollection<Comment>> GetCommentsByMovieAsync(int movieId)
        {
            return await _context.Comments
            .Where(x => x.MovieId == movieId)
            .Include(x => x.User)
            .Include(x => x.Movie)
            .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}