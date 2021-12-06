using LaboratoryMobileAppMVVM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboratoryMobileAppMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PricesPage : ContentPage
    {
        private readonly PricesViewModel _viewModel;

        public PricesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PricesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}