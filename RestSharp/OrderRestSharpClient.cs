using RestSharp;
using RestSharpAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.RestSharp
{
    public class OrderRestSharpClient
    {
        private static readonly RestClient client = new RestClient("https://petstore.swagger.io/v2");

        // Order endpoints
        public static async Task<RestResponse> PlaceOrder(Order order)
        {
            var response = await client.ExecuteAsync(new RestRequest("store/order", Method.Post).AddJsonBody(order));
            return response;
        }
        public static async Task<RestResponse<Order>> GetOrder(long id) => await client.ExecuteAsync<Order>(new RestRequest($"store/order/{id}", Method.Get));
        public static async Task<RestResponse> DeleteOrder(long id) => await client.ExecuteAsync(new RestRequest($"store/order/{id}", Method.Delete));

    }
}
