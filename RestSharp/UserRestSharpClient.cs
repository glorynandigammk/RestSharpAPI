using RestSharp;
using RestSharpAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.RestSharp
{
    internal class UserRestSharpClient
    {
        private static readonly RestClient client = new RestClient("https://petstore.swagger.io/v2");

        public static async Task<RestResponse> CreateUser(User user) => await client.ExecuteAsync(new RestRequest("user", Method.Post).AddJsonBody(user));
        public static async Task<RestResponse<User>> GetUser(string username) => await client.ExecuteAsync<User>(new RestRequest($"user/{username}", Method.Get));
        public static async Task<RestResponse> UpdateUser(string username, User user) => await client.ExecuteAsync(new RestRequest($"user/{username}", Method.Put).AddJsonBody(user));
        public static async Task<RestResponse> DeleteUser(string username) => await client.ExecuteAsync(new RestRequest($"user/{username}", Method.Delete));
    }
}
