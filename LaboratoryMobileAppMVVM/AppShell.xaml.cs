using LaboratoryMobileAppMVVM.Views;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewsDetailPage), typeof(NewsDetailPage));
            Routing.RegisterRoute(nameof(ServiceDetailPage), typeof(ServiceDetailPage));
        }
    }
}
