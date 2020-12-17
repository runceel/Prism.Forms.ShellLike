using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShallEmulation.ViewModels
{
    public class ViewCViewModel : ViewModelBase
    {
        public ViewCViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "ViewC";
        }
    }
}
