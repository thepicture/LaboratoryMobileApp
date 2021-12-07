using LaboratoryMobileAppMVVM.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.ViewModels
{
    public class EditProfileViewModel : ProfileViewModel
    {
        private const int UpdateInterval = 1;

        public EditProfileViewModel()
        {
            Title = "Редактирование профиля";
            Device.StartTimer(TimeSpan.FromSeconds(UpdateInterval), () =>
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
            if (PatientUpdateService.IsSuccessUpdate(CurrentPatient))
            {
                DependencyService.Get<AndroidToast>().Show("Изменения " +
                    "успешно сохранены!");
                CurrentPatient = PatientUpdateService.GetUpdatedObject();
                DependencyService.Get<StoragePatientSerializer>().Serialize
                    (
                        CurrentPatient
                    );
            }
            else
            {
                DependencyService.Get<AndroidToast>().Show("Изменения " +
                    "не сохранены. " +
                    "Попробуйте сохранить изменения ещё раз");
            }
        }
    }
}
