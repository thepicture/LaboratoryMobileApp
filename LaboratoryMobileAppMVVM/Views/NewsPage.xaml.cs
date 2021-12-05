using LaboratoryMobileAppMVVM.Models;
using LaboratoryMobileAppMVVM.ViewModels;
using LaboratoryMobileAppMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboratoryMobileAppMVVM.Views
{
    public partial class NewsPage : ContentPage
    {
        NewsViewModel _viewModel;

        public NewsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new NewsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}