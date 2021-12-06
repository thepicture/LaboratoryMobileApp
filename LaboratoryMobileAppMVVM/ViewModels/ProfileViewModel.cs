using LaboratoryMobileAppMVVM.Services;
using LaboratoryMobileAppMVVM.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; }
        public Command ItemTapped { get; }

        public ProfileViewModel()
        {
            Title = "Профиль";

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command(OnItemSelected);
        }

        private async void OnItemSelected()
        {
            await Shell.Current.GoToAsync($"{nameof(EditProfilePage)}");
        }

        protected async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                CurrentPatient = await DependencyService.Get<StoragePatientDeserializer>().DeserializeAsync();
                CurrentPatient.LoginAndPassword.NewPassword =
                    CurrentPatient.LoginAndPassword.Password;
            }
            catch (Exception ex)
            {
                DependencyService.Get<AndroidToast>().Show("Не удалось " +
                    "получить данные профиля с сервера. " +
                    "Данные вашего профиля могут быть " +
                    "не актуальны");
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
        }
    }
}
