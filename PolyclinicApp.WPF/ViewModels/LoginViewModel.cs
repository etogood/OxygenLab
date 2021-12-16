using PolyclinicApp.WPF.Commands;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;
using System.Collections;
using System.Windows.Input;
using PolyclinicApp.WPF.Stores.Login;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PolyclinicApp.WPF.Factories.Command;

namespace PolyclinicApp.WPF.ViewModels;

internal class LoginViewModel : ViewModel
{
    #region Fields

    private readonly ErrorViewModel _errorViewModel;

    #endregion Fields

    #region Commands

    public ICommand? LogInCommand { get; }

    #endregion Commands

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

    

    #endregion Properties

    #region Ctor

    public LoginViewModel(IHost host)
    {
        _errorViewModel = host.Services.GetRequiredService<ErrorViewModel>();
        MessageViewModel = host.Services.GetRequiredService<MessageViewModel>();
        LogInCommand = host.Services.GetRequiredService<ICommandFactory>().CreateCommand(CommandType.Login);
    }

    #endregion Ctor

    #region Errors

    public IEnumerable? GetErrors(string propertyName)
    {
        return _errorViewModel.GetErrors(propertyName);
    }

    #endregion Errors
}