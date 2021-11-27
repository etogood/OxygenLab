using PolyclinicApp.WPF.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyclinicApp.WPF.Commands;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;

namespace PolyclinicApp.WPF.Factories.Commands
{
    internal class CommandFactory : ICommandFactory
    {
        private readonly INavigationStore _navigationStore;
        private readonly IAuthorizationService _authorizationService;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly LoginViewModel _loginViewModel;

        public CommandFactory(INavigationStore navigationStore, IAuthorizationService authorizationService, IViewModelFactory viewModelFactory, LoginViewModel loginViewModel)
        {
            _navigationStore = navigationStore;
            _authorizationService = authorizationService;
            _viewModelFactory = viewModelFactory;
            _loginViewModel = loginViewModel;
        }

        public BaseCommand? CreateNewCommand(CommandType commandType)
        {
            return commandType switch
            {
                CommandType.Navigation => new NavigationCommand(_navigationStore),
                CommandType.LogIn => new LogInCommand(_navigationStore, _loginViewModel, _authorizationService),
                CommandType.Close => new CloseCommand(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
