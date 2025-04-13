using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using RestSharpAPI.Models;
using RestSharpAPI.Utilities;

namespace RestSharpAPI.API
{
    public static class OrderApiClient
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://petstore.swagger.io/v2/") };

        // Order endpoints
        public static async Task<HttpResponseMessage> PlaceOrderAsync(Order order) => await client.PostAsJsonAsync("store/order", order);


        public static async Task<Order?> GetOrderAsync(long orderId)
        {
            var order = await HttpHelper.GetSafeJsonAsync<Order>(client, $"store/order/{orderId}");
            if (order != null)
            {
                Console.WriteLine($"Order found: {order.Id}");
            }
            else
            {
                Console.WriteLine($"Order with ID {orderId} not found.");
            }
            return order;
        }

        public static async Task<HttpResponseMessage> DeleteOrderAsync(long orderId) => await client.DeleteAsync($"store/order/{orderId}");


    }
}
