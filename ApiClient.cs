using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI
{
    public static class ApiClient
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://petstore.swagger.io/v2/") };

        // Pet endpoints
        public static async Task<HttpResponseMessage> CreatePetAsync(Pet pet) => await client.PostAsJsonAsync("pet", pet);
        public static async Task<Pet> GetPetAsync(long petId)
        {
            var response = await client.GetAsync($"pet/{petId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Pet>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Pet with ID {petId} not found.");
                return null;
            }
            else
            {
                Console.WriteLine($"Failed to fetch pet. Status: {response.StatusCode}");
                return null;
            }
        }

        public static async Task<HttpResponseMessage> UpdatePetAsync(Pet pet) => await client.PutAsJsonAsync("pet", pet);
        public static async Task<HttpResponseMessage> DeletePetAsync(long petId) => await client.DeleteAsync($"pet/{petId}");

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

        // User endpoints
        public static async Task<HttpResponseMessage> CreateUserAsync(User user) => await client.PostAsJsonAsync("user", user);
        public static async Task<User> GetUserAsync(string username)
        {
            var response = await client.GetAsync($"user/{username}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine($"User '{username}' not found.");
                return null;
            }
            else
            {
                Console.WriteLine($"Failed to fetch user. Status: {response.StatusCode}");
                return null;
            }
        }

        public static async Task<HttpResponseMessage> UpdateUserAsync(string username, User user) => await client.PutAsJsonAsync($"user/{username}", user);
        public static async Task<HttpResponseMessage> DeleteUserAsync(string username) => await client.DeleteAsync($"user/{username}");
    }
}
