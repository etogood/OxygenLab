using System;
using PolyclinicApp.WPF.Factories.Commands;
using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Stores;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.ViewModels.Base;

namespace PolyclinicApp.WPF.Factories.ViewModel;

internal class ViewModelFactory : IViewModelFactory
{
    private readonly INavigationStore _navigationStore;
    private readonly ICommandFactory _commandFactory;
    private readonly ErrorViewModel _errorViewModel;
    private readonly MessageViewModel _messageViewModel;

    public ViewModelFactory(INavigationStore navigationStore, ErrorViewModel errorViewModel, MessageViewModel messageViewModel, ICommandFactory commandFactory)
    {
        _navigationStore = navigationStore;
        _errorViewModel = errorViewModel;
        _messageViewModel = messageViewModel;
        _commandFactory = commandFactory;
    }

    public ViewModels.Base.ViewModel? CreateViewModel(ViewType viewType)
    {
        return viewType switch
        {
            ViewType.Login => new LoginViewModel(_errorViewModel, _messageViewModel, _commandFactory),
            ViewType.Information => new InformationViewModel(_navigationStore, this),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null)
        };
    }
}