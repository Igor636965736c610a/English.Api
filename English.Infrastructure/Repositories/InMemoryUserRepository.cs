using English.Core.Entities;
using English.Core.Repositories;
using English.Infrastructure.MyContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly EnglishAppContext _context;
        public InMemoryUserRepository(EnglishAppContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsername(string username)
            => await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

        public async Task<User> GetUserByEmail(string email)
            => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User> GetUserById(Guid id)
            => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<User> GetUserByPassword(string password)
            => await _context.Users.FirstOrDefaultAsync(x => x.Password == password);

        public Task<IEnumerable<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
