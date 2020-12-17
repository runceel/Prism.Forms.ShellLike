using ShallEmulation.ViewModels;
using System.Linq;
using Xamarin.Forms;

namespace ShallEmulation.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            var vm = (MainPageViewModel)BindingContext;
            var topPage = vm.MasterMenuItems.First();
            if (vm.SelectedMenuItem.Path == topPage.Path)
            {
                return base.OnBackButtonPressed();
            }
            else
            {
                vm.SelectedMenuItem = topPage;
                return true;
            }
        }
    }
}