using LaboratoryMobileAppMVVM.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Xamarin.Forms;

namespace LaboratoryMobileAppMVVM.Services
{
    public class PatientUpdateService : IUpdateService<Patient>
    {
        private const string UrlTemplate = "http://10.0.2.2:60954/api/patient/profile";

        private Patient currentPatient;

        public Patient GetUpdatedObject()
        {
            return currentPatient;
        }

        public bool IsSuccessUpdate(Patient entity)
        {
            try
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(Patient));
                MemoryStream stream = new MemoryStream();
                serializer.WriteObject(stream,
                                       entity);

                WebClient client = new WebClient();
                client.Headers.Add("Content-Type", "application/json");
                client.Encoding = System.Text.Encoding.UTF8;
                string jsonPatient = Encoding.UTF8.GetString(stream.ToArray());
                string response = client.UploadString(UrlTemplate,
                                                      WebRequestMethods.Http.Put,
                                                      jsonPatient);
                currentPatient = (Patient)serializer.ReadObject
                    (
                        new MemoryStream(Encoding.UTF8.GetBytes(response))
                    );
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
