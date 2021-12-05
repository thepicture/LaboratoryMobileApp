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
    public class NewsDataStore : IDataStore<ResponseNews>
    {
        private readonly WebClient client;
        private readonly DataContractJsonSerializer serializer;
        private const string UrlTemplate = "http://10.0.2.2:60954/api/";
        public NewsDataStore()
        {
            client = new WebClient();
            serializer = new DataContractJsonSerializer(typeof(ResponseNewsArray));
        }

        public async Task<bool> AddItemAsync(ResponseNews item)
        {
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await Task.FromResult(false);
        }

        public async Task<ResponseNews> GetItemAsync(string id)
        {
            IEnumerable<ResponseNews> news = await GetItemsAsync();
            return await Task.FromResult(news.FirstOrDefault(n => n.Id.ToString() == id));
        }

        public async Task<IEnumerable<ResponseNews>> GetItemsAsync(bool forceRefresh = false)
        {
            string url = Path.Combine(UrlTemplate, "news");
            byte[] response = await client.DownloadDataTaskAsync(new Uri(url));
            ResponseNewsArray news = (ResponseNewsArray)serializer.ReadObject(new MemoryStream(response));
            return await Task.FromResult(news.News);
        }

        public async Task<bool> UpdateItemAsync(ResponseNews item)
        {
            return await Task.FromResult(false);
        }
    }
}
