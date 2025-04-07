using RestSharp;
using RestSharpAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI
{
    public class RestSharpApiClient
    {
        private static readonly RestClient client = new RestClient("https://petstore.swagger.io/v2/");

        // Pet endpoints
        public static async Task<RestResponse> CreatePet(Pet pet) => await client.ExecuteAsync(new RestRequest("pet", Method.Post).AddJsonBody(pet));
        public static async Task<RestResponse<Pet>> GetPet(long id) => await client.ExecuteAsync<Pet>(new RestRequest($"pet/{id}", Method.Get));
        public static async Task<RestResponse> UpdatePet(Pet pet) => await client.ExecuteAsync(new RestRequest("pet", Method.Put).AddJsonBody(pet));
        public static async Task<RestResponse> DeletePet(long id) => await client.ExecuteAsync(new RestRequest($"pet/{id}", Method.Delete));

        // Order endpoints
        public static async Task<RestResponse> PlaceOrder(Order order) => await client.ExecuteAsync(new RestRequest("store/order", Method.Post).AddJsonBody(order));
        public static async Task<RestResponse<Order>> GetOrder(long id) => await client.ExecuteAsync<Order>(new RestRequest($"store/order/{id}", Method.Get));
        public static async Task<RestResponse> DeleteOrder(long id) => await client.ExecuteAsync(new RestRequest($"store/order/{id}", Method.Delete));

        // User endpoints
        public static async Task<RestResponse> CreateUser(User user) => await client.ExecuteAsync(new RestRequest("user", Method.Post).AddJsonBody(user));
        public static async Task<RestResponse<User>> GetUser(string username) => await client.ExecuteAsync<User>(new RestRequest($"user/{username}", Method.Get));
        public static async Task<RestResponse> UpdateUser(string username, User user) => await client.ExecuteAsync(new RestRequest($"user/{username}", Method.Put).AddJsonBody(user));
        public static async Task<RestResponse> DeleteUser(string username) => await client.ExecuteAsync(new RestRequest($"user/{username}", Method.Delete));
    }
}
