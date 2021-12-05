using LaboratoryMobileAppMVVM.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.Views
{
    public partial class NewsDetailPage : ContentPage
    {
        public NewsDetailPage()
        {
            InitializeComponent();
            BindingContext = new NewsDetailViewModel();
        }
    }
}