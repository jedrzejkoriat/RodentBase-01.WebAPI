using Microsoft.AspNetCore.Mvc;
using RodentBase_01.WebAPI.Application.Contracts.Application;
using RodentBase_01.WebAPI.Application.DTOs.Auth;

namespace RodentBase_01.WebAPI.API.Controllers
{
    /// <summary>
    /// Controller for user authentication - no authorization
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/login
        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns>JWT token</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var token = await _authService.AuthenticateUserAsync(userLoginDto);
            return Ok(new { token });
        }



        // POST: api/auth/register
        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="userRegisterDto"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            await _authService.RegisterUserAsync(userRegisterDto);
            return Ok();
        }
    }
}
