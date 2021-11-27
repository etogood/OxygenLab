using PolyclinicApp.WPF.Commands;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;
using System.Collections;
using System.Windows.Input;

namespace PolyclinicApp.WPF.ViewModels;

internal class LoginViewModel : ViewModel
{
    #region Fields

    private readonly ErrorViewModel _errorViewModel;
    private readonly IAuthorizationService _authorizationService;
    private readonly INavigationStore _navigationStore;
    private readonly IViewModelFactory _viewModelFactory;

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

    public LoginViewModel(ErrorViewModel errorViewModel, MessageViewModel messageViewModel, IAuthorizationService authorizationService, INavigationStore navigationStore, IViewModelFactory viewModelFactory)
    {
        _errorViewModel = errorViewModel;
        _authorizationService = authorizationService;
        _navigationStore = navigationStore;
        _viewModelFactory = viewModelFactory;
        MessageViewModel = messageViewModel;
        LogInCommand = new LogInCommand(this, _authorizationService, _navigationStore, _viewModelFactory);
    }

    #endregion Ctor

    #region Errors

    public IEnumerable? GetErrors(string propertyName)
    {
        return _errorViewModel.GetErrors(propertyName);
    }

    #endregion Errors
}