using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.Exceptions;
using OxygenLab.WPF.Services.Users;
using OxygenLab.Data.Models;

namespace OxygenLab.WPF.Services.Authorization
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