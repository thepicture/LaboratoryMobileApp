using LaboratoryMobileAppMVVM.Models;
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace LaboratoryMobileAppMVVM.Services
{
    public class PatientRegisterService : IRegisterService<Patient>
    {


        private readonly WebClient client;
        private readonly DataContractJsonSerializer serializer;
        private const string UrlTemplate = "http://10.0.2.2:60954/api/patient/register";

        public PatientRegisterService()
        {
            client = new WebClient();
            serializer = new DataContractJsonSerializer(typeof(Patient));
        }

        public bool IsSuccessRegister(Patient patient)
        {
            MemoryStream request = new MemoryStream();
            serializer.WriteObject(request, patient);
            try
            {
                string requestPatientJson = Encoding.UTF8.GetString(request.ToArray());
                client.Headers.Add("Content-Type", "application/json");
                client.Encoding = Encoding.UTF8;
                string response = client.UploadString(new Uri(UrlTemplate), requestPatientJson);
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
