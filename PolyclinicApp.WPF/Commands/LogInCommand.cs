﻿using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.Exceptions;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;
using System;
using PolyclinicApp.WPF.Stores.Login;

namespace PolyclinicApp.WPF.Commands
{
    internal class LogInCommand : BaseCommand
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly ILoginStore _loginStore;
        private readonly LoginViewModel _loginViewModel;

        public LogInCommand(LoginViewModel loginViewModel, IAuthorizationService authorizationService, INavigationStore navigationStore, IViewModelFactory viewModelFactory, ILoginStore loginStore)
        {
            _loginViewModel = loginViewModel;
            _authorizationService = authorizationService;
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
            _loginStore = loginStore;
        }

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            var login = _loginViewModel.Login;
            var password = _loginViewModel.Password;

            _loginViewModel.ErrorMessage = string.Empty;

            try
            {
                _authorizationService.Login(login, password);
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
            catch (Exception)
            {
                _loginViewModel.ErrorMessage = "Ошибка авторизации";
            }
        }
    }
}