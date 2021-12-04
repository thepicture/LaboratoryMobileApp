using LaboratoryMobileAppMVVM.ViewModels;
using LaboratoryMobileAppMVVM.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
