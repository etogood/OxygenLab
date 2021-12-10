using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Exceptions;
using PolyclinicApp.WPF.Services.Users;
using PolyclinicApplication.Data.Models;

namespace PolyclinicApp.WPF.Services.Authorization
{
    internal class AuthorizationService : IAuthorizationService
    {
        private readonly IDataService<User> _usersService;

        public AuthorizationService(IHost host)
        {
            _usersService = host.Services.GetRequiredService<IDataService<User>>();
        }

        public User Login(string login, string password)
        {
            var enteredUser = _usersService.GetByLogin(login);

            if (enteredUser == null)
                throw new UserNotFoundException();
            if (password != enteredUser.Password)
                throw new InvalidPasswordException();
            return enteredUser;
        }
    }
}