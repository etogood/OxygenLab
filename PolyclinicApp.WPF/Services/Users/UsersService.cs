using Microsoft.EntityFrameworkCore;
using PolyclinicApp.Data.DataAccess;
using PolyclinicApplication.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolyclinicApp.WPF.Services.Users
{
    internal class UsersService : IDataService<User>
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContextFactory appDbContextFactory)
        {
            _context = appDbContextFactory.CreateDbContext(null);
        }

        public async Task Create(User user)
        {
            await _context.Users!.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User oldUser, User newUser)
        {
            oldUser.Login = newUser.Login;
            oldUser.Password = newUser.Password;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.Users?.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> users = await _context.Users!.ToListAsync();
            return users;
        }

        public User? GetByLogin(string login)
        {
            return _context.Users!.FirstOrDefault(x => x.Login == login);
        }
    }
}