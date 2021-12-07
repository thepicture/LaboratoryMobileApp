using LaboratoryMobileAppMVVM.Models;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.Services
{
    public class StoragePatientDeserializer : IDeserializer<Patient>
    {
        public async Task<Patient> DeserializeAsync()
        {
            DataContractJsonSerializer deserializer = 
                new DataContractJsonSerializer(typeof(Patient));
            string jsonPatient = await SecureStorage.GetAsync("User");
            Patient storagePatient = (Patient)deserializer.ReadObject
                (
                    new MemoryStream(Encoding.UTF8.GetBytes(jsonPatient))
                );
            return DependencyService.Get<PatientLoginService>()
                .IsSuccessLogin(storagePatient.LoginAndPassword.Login,
                                storagePatient.LoginAndPassword.Password)
                ? await Task.FromResult(DependencyService.Get<PatientLoginService>()
                                                         .GetLoginObject())
                : null;
        }
    }
}
