using LaboratoryMobileAppMVVM.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<NewsDataStore>();
            DependencyService.Register<ServiceDataStore>();
            DependencyService.Register<PatientLoginService>();
            DependencyService.Register<AndroidToast>();
            DependencyService.Register<StoragePatientDeserializer>();
            DependencyService.Register<StoragePatientSerializer>();
            DependencyService.Register<PatientRegisterService>();
            DependencyService.Register<PatientUpdateService>();
            SelectAppropriateShell();
        }

        private async void SelectAppropriateShell()
        {
            bool isLoggedIn = await SecureStorage.GetAsync("User") != null;
            if (isLoggedIn)
            {
                MainPage = new LoggedInShell();
            }
            else
            {
                MainPage = new GuestShell();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
