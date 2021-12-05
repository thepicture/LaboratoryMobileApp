using LaboratoryMobileAppMVVM.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class NewsDetailViewModel : BaseViewModel
    {
        private string itemId;
        private ResponseNews currentNews;

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
        public ResponseNews CurrentNews
        {
            get => currentNews; set
            {
                currentNews = value;
                OnPropertyChanged();
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                CurrentNews = await NewsDataStore.GetItemAsync(itemId);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load News");
            }
        }
    }
}
