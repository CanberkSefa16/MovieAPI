using MovieAPI.Data.Entities;

namespace MovieAPI.Data.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment?> GetCommentByIdAsync(int id);
        Task<ICollection<Comment>> GetCommentsByMovieAsync(int movieId);
        Task AddCommentAsync(Comment comment);
        void DeleteComment(Comment comment);
        Task SaveChangesAsync();
    }
}