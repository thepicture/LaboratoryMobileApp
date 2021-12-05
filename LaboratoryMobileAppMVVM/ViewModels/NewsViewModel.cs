using LaboratoryMobileAppMVVM.Models;
using LaboratoryMobileAppMVVM.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        private ResponseNews _selectedItem;

        public ObservableCollection<ResponseNews> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<ResponseNews> ItemTapped { get; }

        public NewsViewModel()
        {
            Title = "Новости лаборатории";
            Items = new ObservableCollection<ResponseNews>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<ResponseNews>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                System.Collections.Generic.IEnumerable<ResponseNews> items = await NewsDataStore.GetItemsAsync(true);
                foreach (ResponseNews item in items)
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

        public ResponseNews SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(ResponseNews item)
        {
            if (item == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(NewsDetailPage)}?{nameof(NewsDetailViewModel.ItemId)}={item.Id}");
        }
    }
}