using RestSharp;
using RestSharpAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.RestSharp
{
    public class PetRestSharpClient 
    {
        private static readonly RestClient client = new RestClient("https://petstore.swagger.io/v2");
        public static async Task<RestResponse> CreatePet(Pet pet)
        {
           var response= await client.ExecuteAsync(new RestRequest("pet", Method.Post).AddJsonBody(pet));
            return response;
        }

        public static async Task<RestResponse> UploadImage(long petId)
        {
            string relativePath = @"Images\puppy.jpeg";
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, relativePath);

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Image file not found.");
                return new RestResponse();
            }
            var request = new RestRequest($"/pet/{petId}/uploadImage", Method.Post);

            request.AddFile("file", filePath, "image/jpeg");

            var response = await client.ExecuteAsync(request);

            Console.WriteLine("Status Code: " + response.StatusCode);
            Console.WriteLine("Response: " + response.Content);
            return response;
        }

        public static async Task<RestResponse<Pet>> GetPet(long id) => await client.ExecuteAsync<Pet>(new RestRequest($"pet/{id}", Method.Get));
        public static async Task<RestResponse> UpdatePet(Pet pet) => await client.ExecuteAsync(new RestRequest("pet", Method.Put).AddJsonBody(pet));
        public static async Task<RestResponse> DeletePet(long id) => await client.ExecuteAsync(new RestRequest($"pet/{id}", Method.Delete));

        public static async Task<RestResponse> FindPetsByStatus(PetStatus status)
        {
            var request = new RestRequest("/pet/findByStatus", Method.Get);
            request.AddParameter("status", status.ToString());

            var response = await client.ExecuteAsync(request);

            Console.WriteLine($"🔍 Status: {status}");
            Console.WriteLine($"📦 Response Code: {response.StatusCode}");
            Console.WriteLine($"📄 Body (truncated): {response.Content?.Substring(0, Math.Min(300, response.Content.Length))}...");
            Console.WriteLine(new string('-', 60));
            return response;
        }
    }
}
