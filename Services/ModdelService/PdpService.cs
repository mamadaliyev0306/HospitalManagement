using HospitalManagement.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.ModdelService
{
    public  class PdpService
    {
        public readonly HttpClient _httpClient;
        public readonly PdpSettings Settings;
        public PdpService(HttpClient httpClient,IOptions<PdpSettings> options) 
        {
            _httpClient = httpClient;
            Settings = options.Value;
        }
        public async Task<string> GetPdpData()
        {
            var endpoint = new Uri(Settings.Endpoint);
            var result = await _httpClient.GetAsync($"?database_Id={Settings.DatabaseId}&page_count={Settings.BatchCount}&all=true");
            return await result.Content.ReadAsStringAsync();
        }
    }
}
