using LaboratoryMobileAppMVVM.Views;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM
{
    public partial class LoggedInShell : Shell
    {
        public LoggedInShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewsDetailPage), typeof(NewsDetailPage));
            Routing.RegisterRoute(nameof(ServiceDetailPage), typeof(ServiceDetailPage));
        }
    }
}
