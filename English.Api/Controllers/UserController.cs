using English.Infrastructure.Commands.Login;
using English.Infrastructure.Commands.User;
using English.Infrastructure.DTO;
using English.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace English.Api.Controllers
{
    [Route("EnglishApi/account")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("user/register")]
        public async Task Register([FromBody] RegisterUser request)
            => await _userService.CreateUser(request.Name, request.UserName, request.Password, request.Email);

        [HttpPost("user/login")]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var token = await _userService.GenerateJwt(request.Email, request.Password);
            return Ok(token);
        }

        [HttpGet("user/username")]
        public async Task<UserDto> GetUserByUsername(string userName)
            => await _userService.GetUserByUsername(userName);

        [HttpGet("user/name")]
        public async Task<IEnumerable<UserDto>> GetUsersByName(string name)
            => await _userService.GetUsersByName(name);

        [HttpGet("user/email")]
        public async Task<UserDto> GetUserByEmail(string email)
            => await _userService.GetUserByEmail(email);
    }
}
