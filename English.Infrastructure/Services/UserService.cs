using AutoMapper;
using English.Core.Entities;
using English.Core.Repositories;
using English.Infrastructure.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        public UserService(IMapper mapper, IUserRepository userRepository, IPasswordHasher<User> passwordHasher,
                   AuthenticationSettings authenticationSettings)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public async Task CreateUser(string name, string username, string password, string email)
        {
            if (name is null || username is null || password is null || email is null)
            {
                throw new NullReferenceException();
            }
            var usernameValidation = await _userRepository.GetUserByUsername(username);
            if(usernameValidation is not null)
            {
                throw new Exception("co ja robie ze swoim życiem o 1 w nocy");
            }
            var emailValidation = await _userRepository.GetUserByEmail(email);
            if(emailValidation is not null)
            {
                throw new Exception("User with that email already exist");
            }

            Guid id = Guid.NewGuid();
            User user = new User(name, username, email, id);
            var hashedPassword = _passwordHasher.HashPassword(user, password);
            user.Password = hashedPassword;
            await _userRepository.CreateUser(user);
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if(user is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByName(string name)
        {
            var users = await _userRepository.GetUsersByName(name);
            if (users is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public Task UpdateUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(string email)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveUser(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            if(user is null)
            {
                throw new Exception("null");
            }
            await _userRepository.RemoveUser(user);
        }

        public async Task RemoveUser(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user is null)
            {
                throw new Exception("null");
            }
            await _userRepository.RemoveUser(user);
        }

        public async Task<string> GenerateJwt(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if(user is null)
            {
                throw new Exception("nieprawidlowy adres email albo haslo");
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if(result == PasswordVerificationResult.Failed)
            {
                throw new Exception("nieprawidlowy adres email albo haslo");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.UserName}"),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
            {
                throw new Exception("null");
            }

            return _mapper.Map<User, UserDto>(user);
        }
    }
}
