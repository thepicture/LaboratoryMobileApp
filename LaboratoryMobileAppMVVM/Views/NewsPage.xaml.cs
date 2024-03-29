﻿using LaboratoryMobileAppMVVM.ViewModels;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.Views
{
    public partial class NewsPage : ContentPage
    {
        private readonly NewsViewModel _viewModel;

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