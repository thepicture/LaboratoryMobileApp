using Android.Preferences;
using LaboratoryMobileAppMVVM.Models;
using LaboratoryMobileAppMVVM.Services;
using LaboratoryMobileAppMVVM.Views;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public string Login
        {
            get => login; set
            {
                login = value;
                IsValid = CanLoginClickedExecute();
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => password; set
            {
                password = value;
                IsValid = CanLoginClickedExecute();
                OnPropertyChanged();
            }
        }

        public bool IsValid
        {
            get => isValid; set
            {
                isValid = value;
                OnPropertyChanged();
            }
        }

        private string login;
        private string password;
        private bool isValid;

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private bool CanLoginClickedExecute()
        {
            return Login != null
                && Password != null
                && Login.Length != 0
                && Password.Length != 0;
        }

        private async void OnLoginClicked(object obj)
        {
            IsValid = false;
            DependencyService.Get<AndroidToast>().Show("Авторизация...");
            if (PatientLoginService.IsSuccessLogin(Login, Password))
            {
                await Task.Run(() => CurrentPatient = PatientLoginService.GetLoginObject());
                DependencyService.Get<AndroidToast>().Show("Вы успешно авторизованы, пациент " +
                    CurrentPatient.FullName);
                SaveLoginData();
                await Shell.Current.GoToAsync($"//{nameof(NewsPage)}");
            }
            else
            {
                DependencyService.Get<AndroidToast>().Show("Неверный логин или пароль. " +
                    "Пожалуйста, проверьте данные авторизации " +
                    "или зарегистрируйтесь");
            }
            IsValid = true;
        }

        private async void SaveLoginData()
        {
            var serializedUser = new MemoryStream();
            new DataContractJsonSerializer(typeof(Patient)).WriteObject(serializedUser, CurrentPatient);
            await SecureStorage.SetAsync("User", Encoding.UTF8.GetString(serializedUser.ToArray()));
            App.Current.MainPage = new LoggedInShell();
        }
    }
}
