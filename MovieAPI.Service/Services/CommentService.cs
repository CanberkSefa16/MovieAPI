using MovieAPI.Data.Entities;
using MovieAPI.Data.Repositories;
using MovieAPI.Service.DTOs;

namespace MovieAPI.Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repo;
        public CommentService(ICommentRepository repo)
        {
            _repo = repo;
        }

        public Task<CommentDto> AddCommentAsync(int userId, CreateCommentDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteComment(int commentId, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CommentDto>> GetCommentsByMovieAsync(int movieId)
        {
            ICollection<Comment> comments = await _repo.GetCommentsByMovieAsync(movieId);
            
            List<CommentDto> commentDtos = comments
                .Select(comment => new CommentDto
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    CreatedAt = comment.CreatedAt,
                    Username = comment.User.Username,
                    MovieTitle = comment.Movie.Title
                })
                .ToList();
            
            return commentDtos;
        }
    }
}