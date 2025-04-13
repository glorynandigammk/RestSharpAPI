using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI
{
    public static class HttpHelper
    {
        public static async Task<T?> GetSafeJsonAsync<T>(HttpClient client, string requestUri)
        {
            var response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine($"{typeof(T).Name} not found at: {requestUri}");
                return default;
            }
            else
            {
                Console.WriteLine($"Error fetching {typeof(T).Name} at {requestUri}. Status: {response.StatusCode}");
                return default;
            }
        }
    }

}
