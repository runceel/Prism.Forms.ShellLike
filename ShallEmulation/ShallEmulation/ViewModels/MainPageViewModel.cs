﻿using Prism.Commands;
using Prism.Navigation;
using System.Linq;
using static Prism.Navigation.KnownNavigationParameters;

namespace ShallEmulation.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private MasterMenuItem _selectedMenuItem;
        public MasterMenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set { SetProperty(ref _selectedMenuItem, value); }
        }

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ??= new DelegateCommand(NavigateExecute);

        private async void NavigateExecute()
        {
            if (SelectedMenuItem is null) return;
            await NavigationService.NavigateAsync(SelectedMenuItem.Path);
        }

        public MasterMenuItem[] MasterMenuItems { get; } = new MasterMenuItem[]
        {
            new("ViewA", "NavigationPage/ViewA"),
            new("ViewB", "NavigationPage/ViewB"),
            new("ViewC", "NavigationPage/ViewC"),
            new("Tab", $"MyTabbedPage?{CreateTab}=NavigationPage|ViewA&" +
                $"{CreateTab}=NavigationPage|ViewB&" +
                $"{CreateTab}=NavigationPage|ViewC&" +
                $"{SelectedTab}=ViewB"),
        };

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Menues";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (SelectedMenuItem is null)
            {
                SelectedMenuItem = MasterMenuItems.First();
                NavigateExecute();
            }
        }
    }

    public record MasterMenuItem(string Text, string Path);
}
