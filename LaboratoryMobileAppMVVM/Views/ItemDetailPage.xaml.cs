using LaboratoryMobileAppMVVM.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}