using English.Infrastructure.DTO;
using English.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace English.Api.Controllers
{
    [Authorize]
    [Route("EnglishApi/User")]
    public class AuthorizeUserController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthorizeUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user")]
        public async Task<UserDto> GetUserById()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = new Guid(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return await _userService.GetUserById(userId);
        }

        [HttpDelete("user/email")]
        public async Task RemoveByEmail()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var email = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            await _userService.RemoveUser(email);
        }            

        [HttpDelete("user")]
        public async Task RemoveById()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = new Guid(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            await _userService.RemoveUser(userId);
        }
    }
}
