using PolyclinicApplication.Data.Models;

namespace PolyclinicApp.WPF.Services.Authorization
{
    internal interface IAuthorizationService
    {
        public User Login(string login, string password);
    }
}