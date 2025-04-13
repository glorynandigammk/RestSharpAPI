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

        public static async Task<Pet?> GetPetAsync(long petId)
        {
            var pet = await HttpHelper.GetSafeJsonAsync<Pet>(client, $"pet/{petId}");
            if (pet != null)
            {
                Console.WriteLine($"Pet found: {pet.Name}");
            }
            else
            {
                Console.WriteLine("Pet not found or error occurred.");
            }
            return pet;
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
