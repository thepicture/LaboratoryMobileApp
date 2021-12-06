using LaboratoryMobileAppMVVM.Models;
using LaboratoryMobileAppMVVM.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.ViewModels
{
    public class EditProfileViewModel : ProfileViewModel
    {
        public EditProfileViewModel()
        {
            Title = "Редактирование профиля";
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                IsValid = CanSaveClickedExecute();
                return true;
            });
        }

        private Command saveChangesCommand;
        private bool isValid;

        public ICommand SaveChangesCommand
        {
            get
            {
                if (saveChangesCommand == null)
                {
                    saveChangesCommand = new Command(SaveChanges);
                }

                return saveChangesCommand;
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

        private bool CanSaveClickedExecute()
        {
            return CurrentPatient.LoginAndPassword.NewPassword != null
                && CurrentPatient.LoginAndPassword.NewPassword.Length != 0
                && CurrentPatient.PhoneNumber != null
                && CurrentPatient.PhoneNumber.Length != 0
                && CurrentPatient.Email != null
                && CurrentPatient.Email.Length != 0;
        }

        private void SaveChanges()
        {
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(Patient));
                var stream = new MemoryStream();
                serializer.WriteObject(stream, CurrentPatient);

                WebClient client = new WebClient();
                client.Headers.Add("Content-Type", "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                string jsonPatient = Encoding.UTF8.GetString(stream.ToArray());
                string response = client.UploadString("http://10.0.2.2:60954/api/patient/profile",
                                                      WebRequestMethods.Http.Put,
                                                      jsonPatient);

                CurrentPatient = (Patient)serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(response)));
                DependencyService.Get<StoragePatientSerializer>().Serialize(CurrentPatient);

                DependencyService.Get<AndroidToast>().Show("Изменения успешно сохранены!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                DependencyService.Get<AndroidToast>().Show("Изменения не сохранены. " +
                    "Попробуйте сохранить изменения ещё раз");
            }
        }
    }
}
