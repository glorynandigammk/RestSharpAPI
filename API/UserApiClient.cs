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
    public static class UserApiClient
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://petstore.swagger.io/v2/") };

       
        public static async Task<HttpResponseMessage> CreateUserAsync(User user) { 
            return await client.PostAsJsonAsync("user", user);            
        }

        public static async Task<User?> GetUserAsync(string username)
        {
            var user = await HttpHelper.GetSafeJsonAsync<User>( client,"user/{username}");

            if (user != null)
            {
                Console.WriteLine($"User found: {user.FirstName} {user.LastName}");
            }
            else
            {
                Console.WriteLine("User not found or error occurred.");
            }
            return user;
        }

        public static async Task<HttpResponseMessage> UpdateUserAsync(string username, User user) => await client.PutAsJsonAsync($"user/{username}", user);
        public static async Task<HttpResponseMessage> DeleteUserAsync(string username) => await client.DeleteAsync($"user/{username}");
    }
}
