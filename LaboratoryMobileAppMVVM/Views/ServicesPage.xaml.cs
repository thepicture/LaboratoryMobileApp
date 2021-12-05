using LaboratoryMobileAppMVVM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboratoryMobileAppMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicesPage : ContentPage
    {
        private readonly ServicesViewModel _viewModel;
        public ServicesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ServicesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}