﻿using LaboratoryMobileAppMVVM.Services;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<NewsDataStore>();
            DependencyService.Register<ServiceDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
