using Application.Repository;
using Domain.Models;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ReadRepositoryApi<T> : IReadRepositoryApi<T> where T : class
    {


        public async Task<List<T>> List(Dictionary<string, string> condition = null)
        {
            HttpClient client = new HttpClient();
            string result = string.Empty;
            string url = "https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear";
            if (condition != null)
            {
                foreach(var c in condition)
                {
                    url += "/" + c.Key + "/" + c.Value;
                }
            }
            url += "?format=json";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            var returnValue = JsonSerializer.Deserialize<Header<T>>(result);
            return new List<T>(returnValue.Results);
        }
    }
}
