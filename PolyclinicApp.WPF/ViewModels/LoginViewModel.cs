using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using PolyclinicApp.WPF.Commands;
using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.Factories.Commands;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Stores;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;

namespace PolyclinicApp.WPF.ViewModels;

internal class LoginViewModel : ViewModel
{
    #region Fields

    private readonly ErrorViewModel _errorViewModel;

    #endregion

    #region Commands

    public ICommand? LogInCommand { get; }

    #endregion

    #region Properties

    private string _login;

    public string Login
    {
        get => _login;
        set => Set(ref _login, value);
        
    }

    private string _password;

    public string Password
    {
        get => _password;
        set => Set(ref _password, value);
        
    }

    public MessageViewModel MessageViewModel { get; set; }

    public string? ErrorMessage
    {
        set => MessageViewModel.Message = value;
    }



    #endregion

    #region Ctor

    public LoginViewModel(ErrorViewModel errorViewModel, MessageViewModel messageViewModel, ICommandFactory commandFactory)
    {
        _errorViewModel = errorViewModel;
        MessageViewModel = messageViewModel;
        LogInCommand = commandFactory.CreateNewCommand(CommandType.LogIn);
    }

    #endregion

    #region Errors

    public IEnumerable? GetErrors(string propertyName)
    {
        return _errorViewModel.GetErrors(propertyName);
    }

    #endregion
}

