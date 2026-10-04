using MovieAPI.Service.DTOs;

namespace MovieAPI.Service.Services
{
    public interface IUserService
    {
        Task<ICollection<UserDto>> GetUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<UserDto?> AddUserAsync(CreateUserDto dto);
        Task UpdateUserAsync(int id, UpdateUserDto dto);
        Task DeleteUserAsync(int id);
    }
}