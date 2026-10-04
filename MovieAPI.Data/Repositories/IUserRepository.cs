using MovieAPI.Data.Entities;

namespace MovieAPI.Data.Repositories
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        void DeleteUser(User user);
        Task SaveChangesAsync();
        Task<bool> EmailExistsAsync(string email);
        Task<bool> UsernameExistsAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);

    }
}