using LaboratoryMobileAppMVVM.Models;
using LaboratoryMobileAppMVVM.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegiserClicked);
            CurrentPatient = new Patient();
        }

        public Command RegisterCommand { get; }
        public string Login
        {
            get => login; set
            {
                login = value;
                IsValid = value.Length > 0;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password; set
            {
                password = value;
                IsValid = value.Length > 0;
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

        public string InsuranceNumber
        {
            get => insuranceNumber; set
            {
                insuranceNumber = value;
                IsValid = value.Length > 0;
                OnPropertyChanged();
            }
        }

        private const int DaysInYear = 365;
        private const int MaxPatientAge = 100;

        public DateTime BirthDate
        {
            get => birthDate; set
            {
                birthDate = value;
                IsValid = value < DateTime.Now
                          && value > DateTime.Now - TimeSpan.FromDays
                          (
                              DaysInYear * MaxPatientAge
                          );
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => email; set
            {
                email = value;
                IsValid = value.Length > 0;
                OnPropertyChanged();
            }
        }
        public string Phone
        {
            get => phone; set
            {
                phone = value;
                IsValid = value.Length > 0;
                OnPropertyChanged();
            }
        }
        public string PassNumber
        {
            get => passNumber; set
            {
                passNumber = value;
                IsValid = value.Length > 0;
                OnPropertyChanged();
            }
        }
        public string PassSeries
        {
            get => passSeries; set
            {
                passSeries = value;
                IsValid = value.Length > 0;
                OnPropertyChanged();
            }
        }
        public string FullName
        {
            get => fullName; set
            {
                fullName = value;
                IsValid = value.Length > 0;
                OnPropertyChanged();
            }
        }

        private string login;
        private string password;
        private string insuranceNumber;
        private DateTime birthDate;
        private string email;
        private string phone;
        private string passNumber;
        private string passSeries;
        private string fullName;
        private bool isValid;

        private async void OnRegiserClicked(object obj)
        {
            Patient patient = new Patient
            {
                FullName = FullName,
                BirthDate = BirthDate.ToString(),
                Email = Email,
                InsuranceNumber = InsuranceNumber,
                LoginAndPassword = new RequestLoginPatient
                {
                    Login = Login,
                    Password = Password
                },
                PassNum = PassNumber,
                PassSeries = PassSeries,
                PhoneNumber = Phone
            };
            IsValid = false;
            DependencyService.Get<AndroidToast>().Show("Регистрация...");
            if (PatientRegisterService.IsSuccessRegister(patient))
            {
                _ = await Task.Run(() => CurrentPatient =
                PatientLoginService.GetLoginObject());
                DependencyService.Get<AndroidToast>().Show("Вы успешно " +
                    "зарегистрированы, пациент " +
                    FullName);
            }
            else
            {
                DependencyService.Get<AndroidToast>().Show("Не удалось " +
                    "зарегистрироваться. " +
                    "Пожалуйста, проверьте данные регистрации " +
                    "и убедитесь, что пациент с указанным логином " +
                    "не существует в системе");
            }
            IsValid = true;
        }
    }
}
