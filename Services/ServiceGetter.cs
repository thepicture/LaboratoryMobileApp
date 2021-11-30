using LaboratoryMobileApp.Models;
using System.Collections.Generic;
using System.Json;
using System.Net;

namespace LaboratoryMobileApp.Services
{
    public class ServiceGetter : IGetter<ResponseService>
    {
        private readonly WebClient _client;
        private readonly string _baseApiTemplate = "http://localhost:60954/api/";
        public ServiceGetter()
        {
            _client = new WebClient();
        }
        public IEnumerable<ResponseService> Get()
        {
            List<ResponseService> result = new List<ResponseService>();

            string response = _client.DownloadString(_baseApiTemplate + "/service");
            JsonValue services = JsonArray.Parse(response);
            foreach (JsonValue service in services)
            {
                string name = service["name"];
                decimal price = decimal.Parse(service["price"]);
                ResponseService responseService = new ResponseService(name, price);
                result.Add(responseService);
            }
            return result;
        }
    }
}