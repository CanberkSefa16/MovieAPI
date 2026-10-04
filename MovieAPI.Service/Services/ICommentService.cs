using MovieAPI.Service.DTOs;

namespace MovieAPI.Service.Services
{
    public interface ICommentService
    {
        Task<ICollection<CommentDto>> GetCommentsByMovieAsync(int movieId);
        Task<CommentDto> AddCommentAsync(int userId, CreateCommentDto dto);
        Task DeleteComment(int commentId, int userId);
    }
}