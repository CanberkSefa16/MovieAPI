using MovieAPI.Data.Entities;
using MovieAPI.Service.DTOs;

namespace MovieAPI.Service.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto dto);
    }
}