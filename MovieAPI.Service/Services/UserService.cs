
using MovieAPI.Data.Entities;
using MovieAPI.Data.Repositories;
using MovieAPI.Service.DTOs;
using Microsoft.AspNetCore.Identity;
using MovieAPI.Service.Exceptions;

namespace MovieAPI.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository repo, IPasswordHasher<User> passwordHasher)
        {
            _repo = repo;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> AddUserAsync(CreateUserDto dto)
        {
            if (await _repo.UsernameExistsAsync(dto.Username))
                throw new ConflictException("Username already exists.");

            if (await _repo.EmailExistsAsync(dto.Email))
                throw new ConflictException("Email already exists.");

            var user = new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = string.Empty
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            await _repo.AddUserAsync(user);
            await _repo.SaveChangesAsync();

            UserDto userDto = new UserDto
            {
                Id = user.Id,
                Name =user.Name,
                Surname = user.Surname,
                Username = user.Username,
                Email = user.Email
            };

            return userDto;
        }

        public async Task DeleteUserAsync(int id)
        {
            User? existed = await _repo.GetUserByIdAsync(id);

            if(existed == null)
            {
                throw new NotFoundException("User not found.");
            }

            _repo.DeleteUser(existed);
            await _repo.SaveChangesAsync();
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            User? user = await _repo.GetUserByIdAsync(id);

            if (user == null)
                throw new NotFoundException("User not found.");
            
            UserDto userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username,
                Email = user.Email
            };

            return userDto;
        }

        public async Task<ICollection<UserDto>> GetUsersAsync()
        {
            ICollection<User> users = await _repo.GetAllUsersAsync();
            ICollection<UserDto> userDtos = new List<UserDto>();

            foreach(User item in users)
            {
                UserDto userDto = new UserDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Username = item.Username,
                    Email = item.Email
                };

                userDtos.Add(userDto);
            }

            return userDtos;
        }

        public async Task UpdateUserAsync(int id, UpdateUserDto dto)
        {
            User? user = await _repo.GetUserByIdAsync(id);

            if(user == null)
                throw new NotFoundException("User not found");
            
            if(user.Username != dto.Username)
            {
                bool usernameExisted = await _repo.UsernameExistsAsync(dto.Username);

                if(usernameExisted)
                    throw new ConflictException("Username already exists.");
            }

            if(user.Email != dto.Email)
            {
                bool emailExisted = await _repo.EmailExistsAsync(dto.Email);

                if(emailExisted)
                    throw new ConflictException("Email already exists.");
            }
            
            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.Username = dto.Username;
            user.Email = dto.Email;

            await _repo.SaveChangesAsync();

        }
    }
}