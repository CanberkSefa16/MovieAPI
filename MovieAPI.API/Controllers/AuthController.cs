using Microsoft.AspNetCore.Mvc;
using MovieAPI.Service.DTOs;
using MovieAPI.Service.Services;

namespace MovieAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            LoginResponseDto response = await _authService.LoginAsync(dto);

            return Ok(response);
        }
    }
}