using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using RestSharpAPI.Models;

namespace RestSharpAPI.API
{
    public static class OrderApiClient
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://petstore.swagger.io/v2/") };

        // Order endpoints
        public static async Task<HttpResponseMessage> PlaceOrderAsync(Order order) => await client.PostAsJsonAsync("store/order", order);
        public static async Task<Order> GetOrderAsync(long orderId)
        {
            var response = await client.GetAsync($"store/order/{orderId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Order>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Order with ID {orderId} not found.");
                return null;
            }
            else
            {
                Console.WriteLine($"Failed to fetch order. Status: {response.StatusCode}");
                return null;
            }
        }

        public static async Task<HttpResponseMessage> DeleteOrderAsync(long orderId) => await client.DeleteAsync($"store/order/{orderId}");


    }
}
