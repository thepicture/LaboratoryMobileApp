using LaboratoryMobileAppMVVM.Models;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Xamarin.Essentials;

namespace LaboratoryMobileAppMVVM.Services
{
    public class StoragePatientSerializer : ISerializer<Patient>
    {
        public async void Serialize(Patient entity)
        {
            MemoryStream serializedUser = new MemoryStream();
            new DataContractJsonSerializer(typeof(Patient)).WriteObject
                (
                    serializedUser, entity
                );
            string userAsJson = Encoding.UTF8.GetString(serializedUser.ToArray());
            await SecureStorage.SetAsync("User",
                                         userAsJson);
        }
    }
}
