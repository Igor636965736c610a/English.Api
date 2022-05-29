using English.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.Services
{
    public interface IUserService
    {
        Task CreateUser(string name, string username, string password, string email);
        Task<UserDto> GetUser(string username);
        Task<UserDto> GetUserByEmail(string email);
        Task<UserDto> GetUserById(Guid id);
    }
}
