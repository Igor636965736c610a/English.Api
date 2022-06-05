using English.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Core.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByName(string name);
        Task<IEnumerable<User>> GetAllUsers();
        Task RemoveUser(Guid id);
        Task RemoveUser(string username);      
    }
}
