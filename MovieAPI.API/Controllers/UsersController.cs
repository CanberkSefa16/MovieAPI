
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data.Entities;
using MovieAPI.Service.DTOs;
using MovieAPI.Service.Services;

namespace MovieAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            ICollection<UserDto> users = await _service.GetUsersAsync();
            
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            UserDto? user = await _service.GetUserByIdAsync(id);

            if(user == null)
                return NotFound();
            
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserDto dto)
        {
            UserDto? userDto = await _service.AddUserAsync(dto);
            
            if(userDto == null)
                return Conflict();

            return CreatedAtAction(
                nameof(GetUserById),
                new { id = userDto.Id },
                dto
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            bool deleted = await _service.DeleteUserAsync(id);

            if(!deleted)
                return NotFound();
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto dto)
        {
            bool updated = await _service.UpdateUserAsync(id, dto);

            if(!updated)
                return NotFound();
            
            return NoContent();
        }
    }
}