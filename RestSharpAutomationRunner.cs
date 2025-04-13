using RestSharpAPI.Models;
using System;
using System.Threading.Tasks;

namespace RestSharpAPI
{
    public class RestSharpAutomationRunner
    {
        public static async Task RunPetAutomation()
        {
            // 1. Create a new Pet
            var newPet = new Pet
            {
                Id = 123456,
                Name = "Fluffy",
                Status = "available"
            };

            Console.WriteLine("Creating Pet...");
            var createResponse = await RestSharpApiClient.CreatePet(newPet);
            Console.WriteLine($"Create Status: {createResponse.StatusCode}");

            // 2. Get the Pet
            Console.WriteLine("Getting Pet...");
            var getResponse = await RestSharpApiClient.GetPet(newPet.Id);
            Console.WriteLine($"Pet Retrieved: {getResponse.Data?.Name}");

            // 3. Update the Pet
            newPet.Name = "FluffyUpdated";
            newPet.Status = "sold";
            Console.WriteLine("Updating Pet...");
            var updateResponse = await RestSharpApiClient.UpdatePet(newPet);
            Console.WriteLine($"Update Status: {updateResponse.StatusCode}");

            // 4. Get again to confirm update
            var getUpdatedResponse = await RestSharpApiClient.GetPet(newPet.Id);
            Console.WriteLine($"Updated Pet: {getUpdatedResponse.Data?.Name}, Status: {getUpdatedResponse.Data?.Status}");

            // 5. Delete the Pet
            Console.WriteLine("Deleting Pet...");
            var deleteResponse = await RestSharpApiClient.DeletePet(newPet.Id);
            Console.WriteLine($"Delete Status: {deleteResponse.StatusCode}");

            // 6. Confirm deletion
            Console.WriteLine("Verifying Deletion...");
            var getAfterDelete = await RestSharpApiClient.GetPet(newPet.Id);
            Console.WriteLine(getAfterDelete.StatusCode == System.Net.HttpStatusCode.NotFound
                ? "Pet successfully deleted."
                : "Pet still exists.");
        }
    }

}
