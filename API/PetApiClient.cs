using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using RestSharpAPI.Models;

namespace RestSharpAPI.API
{
    public static class PetApiClient
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://petstore.swagger.io/v2/") };

        // Pet endpoints
        public static async Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            return await client.PostAsJsonAsync("pet", pet);
        }

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

        public static async Task<HttpResponseMessage> UpdatePetAsync(Pet pet)
        {
            return await client.PutAsJsonAsync("pet", pet);
        }

        public static async Task<HttpResponseMessage> DeletePetAsync(long petId)
        {
            return await client.DeleteAsync($"pet/{petId}");
        }
    }
}
