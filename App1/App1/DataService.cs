﻿using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace App1
{
    class DataService
    {
        public static async Task<JContainer> getDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            JContainer Data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                Data = (JContainer)JsonConvert.DeserializeObject(json);
            }

            return Data;
        }
    }
}
