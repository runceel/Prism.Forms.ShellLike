using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShallEmulation.ViewModels
{
    public class MyTabbedPageViewModel : ViewModelBase
    {
        public MyTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "My tabs";
        }
    }
}
