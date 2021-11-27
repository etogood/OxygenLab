using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.ViewModels.Base;
using System;
using PolyclinicApp.Data.DataAccess;

namespace PolyclinicApp.WPF.Factories.ViewModel;

internal class ViewModelFactory : IViewModelFactory
{
    private readonly INavigationStore _navigationStore;
    private readonly ErrorViewModel _errorViewModel;
    private readonly MessageViewModel _messageViewModel;
    private readonly IAuthorizationService _authorizationService;
    private readonly AppDbContextFactory _appDbContextFactory;

    public ViewModelFactory(INavigationStore navigationStore, ErrorViewModel errorViewModel, MessageViewModel messageViewModel, IAuthorizationService authorizationService, AppDbContextFactory appDbContextFactory)
    {
        _navigationStore = navigationStore;
        _errorViewModel = errorViewModel;
        _messageViewModel = messageViewModel;
        _authorizationService = authorizationService;
        _appDbContextFactory = appDbContextFactory;
    }

    public ViewModels.Base.ViewModel? CreateViewModel(ViewType viewType)
    {
        return viewType switch
        {
            ViewType.Login => new LoginViewModel(_errorViewModel, _messageViewModel, _authorizationService, _navigationStore, this),
            ViewType.Information => new InformationViewModel(_navigationStore, this, _appDbContextFactory),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null)
        };
    }
}