﻿using English.Infrastructure.Commands.Login;
using English.Infrastructure.Commands.User;
using English.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace English.Api.Controllers
{
    [Route("EnglishApi/account")]
    public class UserController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task Register([FromBody] RegisterUser request)
            => await _userService.CreateUser(request.Name, request.UserName, request.Password, request.Email);
        
        [HttpPost("login")]
        public async Task<string> Login([FromBody] Login request)
        {
            string token = await _userService.GenerateJwt(request.Email, request.Password);
            return token;
        }
    }
}
