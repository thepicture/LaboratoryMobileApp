using LaboratoryMobileAppMVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace LaboratoryMobileAppMVVM.Services
{
    public class ServiceDataStore : IDataStore<ResponseService>
    {
        private readonly WebClient client;
        private readonly DataContractJsonSerializer serializer;
        private const string UrlTemplate = "http://10.0.2.2:60954/api/";
        public ServiceDataStore()
        {
            client = new WebClient();
            serializer = new DataContractJsonSerializer(typeof(ResponseServicesArray));
        }

        public async Task<bool> AddItemAsync(ResponseService item)
        {
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await Task.FromResult(false);
        }

        public async Task<ResponseService> GetItemAsync(string id)
        {
            IEnumerable<ResponseService> news = await GetItemsAsync();
            return await Task.FromResult
                (
                    news.FirstOrDefault(n => n.Id.ToString() == id)
                );
        }

        public async Task<IEnumerable<ResponseService>> GetItemsAsync
            (
                bool forceRefresh = false
            )
        {
            string url = Path.Combine(UrlTemplate, "service");
            byte[] response = await client.DownloadDataTaskAsync(new Uri(url));
            ResponseServicesArray services = (ResponseServicesArray)serializer
                .ReadObject(new MemoryStream(response));
            return await Task.FromResult(services.Services);
        }

        public async Task<bool> UpdateItemAsync(ResponseService item)
        {
            return await Task.FromResult(false);
        }
    }
}
