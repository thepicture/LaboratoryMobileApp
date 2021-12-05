using LaboratoryMobileAppMVVM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboratoryMobileAppMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceDetailPage : ContentPage
    {
        public ServiceDetailPage()
        {
            InitializeComponent();

            BindingContext = new ServiceDetailViewModel();
        }
    }
}