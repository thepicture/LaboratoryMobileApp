using LaboratoryMobileAppMVVM.Services;
using LaboratoryMobileAppMVVM.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; }
        public Command ItemTapped { get; }
        public Command LogOut { get; }

        public ProfileViewModel()
        {
            Title = "Профиль";

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command(OnItemSelected);
            LogOut = new Command(OnLogOut);
        }

        private void OnLogOut()
        {
            if (SecureStorage.Remove("User"))
            {
                App.Current.MainPage = new GuestShell();
                DependencyService.Get<AndroidToast>().Show("Вы успешно " +
                    "вышли из аккаунта");
            }
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
                CurrentPatient = await DependencyService
                                       .Get<StoragePatientDeserializer>()
                                       .DeserializeAsync();
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
