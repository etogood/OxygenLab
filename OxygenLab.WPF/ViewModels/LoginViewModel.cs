using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections;
using System.Windows.Input;
using OxygenLab.Data.Models;
using OxygenLab.WPF.Factories.Command;
using OxygenLab.WPF.ViewModels.Base;

namespace OxygenLab.WPF.ViewModels;

internal class LoginViewModel : ViewModel
{

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
        MessageViewModel = host.Services.GetRequiredService<MessageViewModel>();
        LogInCommand = host.Services.GetRequiredService<ICommandFactory>().CreateCommand(CommandType.Login);
    }

    #endregion Ctor

}