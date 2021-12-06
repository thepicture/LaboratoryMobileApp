using LaboratoryMobileAppMVVM.Models;
using LaboratoryMobileAppMVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.ViewModels
{
    public class ServicesViewModel : BaseViewModel
    {
        private ResponseService _selectedItem;

        public ObservableCollection<ResponseService> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<ResponseService> ItemTapped { get; }

        public ServicesViewModel()
        {
            Title = "Список услуг";
            Items = new ObservableCollection<ResponseService>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<ResponseService>(OnItemSelected);
        }

        protected async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                IEnumerable<ResponseService> items =
                    await ServiceDataStore.GetItemsAsync(true);
                foreach (ResponseService item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public ResponseService SelectedItem
        {
            get => _selectedItem;
            set
            {
                _ = SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnItemSelected(ResponseService item)
        {
            if (item == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(ServiceDetailPage)}" +
                $"?{nameof(ServiceDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
