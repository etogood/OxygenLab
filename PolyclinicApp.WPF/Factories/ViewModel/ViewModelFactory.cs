using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.ViewModels.Base;
using System;

namespace PolyclinicApp.WPF.Factories.ViewModel;

internal class ViewModelFactory : IViewModelFactory
{
    private readonly INavigationStore _navigationStore;
    private readonly ErrorViewModel _errorViewModel;
    private readonly MessageViewModel _messageViewModel;
    private readonly IAuthorizationService _authorizationService;

    public ViewModelFactory(INavigationStore navigationStore, ErrorViewModel errorViewModel, MessageViewModel messageViewModel, IAuthorizationService authorizationService)
    {
        _navigationStore = navigationStore;
        _errorViewModel = errorViewModel;
        _messageViewModel = messageViewModel;
        _authorizationService = authorizationService;
    }

    public ViewModels.Base.ViewModel? CreateViewModel(ViewType viewType)
    {
        return viewType switch
        {
            ViewType.Login => new LoginViewModel(_errorViewModel, _messageViewModel, _authorizationService, _navigationStore, this),
            ViewType.Information => new InformationViewModel(_navigationStore, this),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null)
        };
    }
}