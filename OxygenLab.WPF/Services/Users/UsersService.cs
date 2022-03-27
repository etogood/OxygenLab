using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OxygenLab.Data.DataAccess;

namespace OxygenLab.WPF.Services.Users
{
    internal class UsersService : IDataService<User>, IDisposable
    {
        private readonly AppDbContext _context;

        public UsersService(IHost host)
        {
            _context = host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new []{"Default"});
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

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}