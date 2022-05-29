using AutoMapper;
using English.Core.Entities;
using English.Core.Repositories;
using English.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task CreateUser(string name, string username, string password, string email)
        {
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
            User user = new User(name, username, password, email, id);
            await _userRepository.CreateUser(user);
        }

        public async Task<UserDto> GetUser(string username)
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
