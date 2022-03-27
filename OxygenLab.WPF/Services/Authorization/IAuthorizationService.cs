using OxygenLab.Data.Models;

namespace OxygenLab.WPF.Services.Authorization
{
    internal interface IAuthorizationService
    {
        public User Login(string login, string password);
    }
}