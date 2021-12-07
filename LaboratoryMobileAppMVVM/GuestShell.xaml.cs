using LaboratoryMobileAppMVVM.Views;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM
{
    public partial class GuestShell : Shell
    {
        public GuestShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewsDetailPage), typeof(NewsDetailPage));
            Routing.RegisterRoute(nameof(ServiceDetailPage), typeof(ServiceDetailPage));
        }
    }
}
