using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OxygenLab.WPF.Commands.Base;
using OxygenLab.WPF.Exceptions;
using OxygenLab.WPF.Factories.ViewModel;
using OxygenLab.WPF.Services.Authorization;
using OxygenLab.WPF.Stores.Login;
using OxygenLab.WPF.Stores.Navigation;
using OxygenLab.WPF.ViewModels;

namespace OxygenLab.WPF.Commands
{
    internal class LogInCommand : BaseCommand
    {
        private readonly INavigationStore _navigationStore;
        private readonly IAuthorizationService _authorizationService;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly ILoginStore _loginStore;
        private LoginViewModel _loginViewModel;

        public LogInCommand(IHost host)
        {
            _authorizationService = host.Services.GetRequiredService<IAuthorizationService>();
            _navigationStore = host.Services.GetRequiredService<INavigationStore>();
            _viewModelFactory = host.Services.GetRequiredService<IViewModelFactory>();
            _loginStore = host.Services.GetRequiredService<ILoginStore>();
        }

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            _loginViewModel = (LoginViewModel)_viewModelFactory.CreateViewModel(ViewType.Login)!;
            var login = _loginViewModel.Login;
            var password = _loginViewModel.Password;

            _loginViewModel.ErrorMessage = string.Empty;

            try
            {
                _loginStore.CurrentUser = _authorizationService.Login(login, password);
                if (_loginViewModel.MessageViewModel.HasMessage) return;
                _navigationStore.CurrentViewModel = _viewModelFactory.CreateViewModel(ViewType.Information);
                _loginStore.IsLoggedIn = true;
                
            }
            catch (UserNotFoundException)
            {
                _loginViewModel.ErrorMessage = "Пользователь с таким логином не найден";
            }
            catch (InvalidPasswordException)
            {
                _loginViewModel.ErrorMessage = "Введён неверный пароль";
            }
            catch (AppDomainUnloadedException)
            {
                _loginViewModel.ErrorMessage = "Ошибка авторизации";
            }
        }
    }
}