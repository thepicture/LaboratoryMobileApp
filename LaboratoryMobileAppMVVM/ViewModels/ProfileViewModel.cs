using LaboratoryMobileAppMVVM.Models;
using LaboratoryMobileAppMVVM.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; }

        public ProfileViewModel()
        {
            Title = "Профиль";

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        protected async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Patient));
                string jsonPatient = await SecureStorage.GetAsync("User");
                Patient storagePatient = (Patient)deserializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(jsonPatient)));
                if (PatientLoginService.IsSuccessLogin(storagePatient.LoginAndPassword.Login,
                    storagePatient.LoginAndPassword.Password))
                {
                    CurrentPatient = PatientLoginService.GetLoginObject();
                }
                else
                {
                    DependencyService.Get<AndroidToast>().Show("Не удалось " +
                        "получить данные профиля с сервера. " +
                        "Данные вашего профиля могут быть " +
                        "не актуальны");
                    CurrentPatient = storagePatient;
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
        }
    }
}
