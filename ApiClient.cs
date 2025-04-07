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
        public static async Task<Pet> GetPetAsync(long petId) => await client.GetFromJsonAsync<Pet>($"pet/{petId}");
        public static async Task<HttpResponseMessage> UpdatePetAsync(Pet pet) => await client.PutAsJsonAsync("pet", pet);
        public static async Task<HttpResponseMessage> DeletePetAsync(long petId) => await client.DeleteAsync($"pet/{petId}");

        // Order endpoints
        public static async Task<HttpResponseMessage> PlaceOrderAsync(Order order) => await client.PostAsJsonAsync("store/order", order);
        public static async Task<Order> GetOrderAsync(long orderId) => await client.GetFromJsonAsync<Order>($"store/order/{orderId}");
        public static async Task<HttpResponseMessage> DeleteOrderAsync(long orderId) => await client.DeleteAsync($"store/order/{orderId}");

        // User endpoints
        public static async Task<HttpResponseMessage> CreateUserAsync(User user) => await client.PostAsJsonAsync("user", user);
        public static async Task<User> GetUserAsync(string username) => await client.GetFromJsonAsync<User>($"user/{username}");
        public static async Task<HttpResponseMessage> UpdateUserAsync(string username, User user) => await client.PutAsJsonAsync($"user/{username}", user);
        public static async Task<HttpResponseMessage> DeleteUserAsync(string username) => await client.DeleteAsync($"user/{username}");
    }
}
