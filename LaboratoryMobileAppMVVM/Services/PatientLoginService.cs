using LaboratoryMobileAppMVVM.Models;
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace LaboratoryMobileAppMVVM.Services
{
    public class PatientLoginService : ILoginService<Patient>
    {
        private readonly WebClient client;
        private readonly DataContractJsonSerializer serializer;
        private readonly DataContractJsonSerializer deserializer;
        private Patient patient;
        private const string UrlTemplate = "http://10.0.2.2:60954/api/patient/login";

        public PatientLoginService()
        {
            client = new WebClient();
            serializer = new DataContractJsonSerializer(typeof(RequestLoginPatient));
            deserializer = new DataContractJsonSerializer(typeof(Patient));
        }

        public Patient GetLoginObject()
        {
            return patient;
        }

        public bool IsSuccessLogin(string login, string password)
        {
            RequestLoginPatient requestPatient = new RequestLoginPatient
            {
                Login = login,
                Password = password
            };
            MemoryStream request = new MemoryStream();
            serializer.WriteObject(request, requestPatient);
            try
            {
                string requestPatientJson = Encoding.UTF8.GetString(request.ToArray());
                client.Headers.Add("Content-Type", "application/json");
                client.Encoding = Encoding.UTF8;
                string response = client.UploadString(new Uri(UrlTemplate), requestPatientJson);
                try
                {
                    patient = (Patient)deserializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(response)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
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
