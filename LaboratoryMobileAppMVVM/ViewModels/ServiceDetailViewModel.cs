using LaboratoryMobileAppMVVM.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ServiceDetailViewModel : BaseViewModel
    {
        private string itemId;
        private ResponseService currentService;

        public ServiceDetailViewModel()
        {
            Title = "Информация об услуге";
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }
        public ResponseService CurrentService
        {
            get => currentService; set
            {
                currentService = value;
                OnPropertyChanged();
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                CurrentService = await ServiceDataStore.GetItemAsync(itemId);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Service");
            }
        }
    }
}
