using RestSharp;
using RestSharpAPI.Models;
using RestSharpAPI.RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace RestSharpAPI.AutomationRunner
{
    public class PetAutomationRunner
    {
        public static async Task Run()
        {
            Console.WriteLine("----- PET AUTOMATION -----");

            // 1. Create a new Pet
            var newPet = new Pet
            {
                id = 123456,
                name = "Fluffy",
                status =PetStatus.available.ToString(),
            };

            Console.WriteLine("Creating Pet...");
            var createResponse = await PetRestSharpClient.CreatePet(newPet);
            Console.WriteLine($"Create Status: {createResponse.StatusCode}");         


            // 2. Get the Pet
            Console.WriteLine("Getting Pet...");
            var getResponse = await PetRestSharpClient.GetPet(newPet.id);
            Console.WriteLine($"Pet Retrieved: {getResponse.Data?.name}");
            if (createResponse.StatusCode == HttpStatusCode.OK)
                TestAssertions.TestAssertions.AssertPetEqual(getResponse.Data!, newPet);

            // 3. Update the Pet
            newPet.name = "FluffyUpdated";
            newPet.status = PetStatus.sold.ToString();
            Console.WriteLine("Updating Pet...");
            var updateResponse = await PetRestSharpClient.UpdatePet(newPet);
            Console.WriteLine($"Update Status: {updateResponse.StatusCode}");

            // 4. Get again to confirm update
            var getUpdatedResponse = await PetRestSharpClient.GetPet(newPet.id);
            Console.WriteLine($"Updated Pet: {getUpdatedResponse.Data?.name}, Status: {getUpdatedResponse.Data?.status}");
            if (createResponse.StatusCode == HttpStatusCode.OK)
                TestAssertions.TestAssertions.AssertPetEqual(getResponse.Data!, newPet);

            // 5. Delete the Pet
            Console.WriteLine("Deleting Pet...");
            var deleteResponse = await PetRestSharpClient.DeletePet(newPet.id);
            Console.WriteLine($"Delete Status: {deleteResponse.StatusCode}");
         

            // 6. Upload Image
            Console.WriteLine("Upload Image...");
            var resposeAfterImageUpload = await PetRestSharpClient.UploadImage(newPet.id);
            Console.WriteLine(resposeAfterImageUpload.StatusCode == System.Net.HttpStatusCode.OK
                   ? "Successfully uploaded Pet Image." : "Image not found.");

            //7. Find pets by Status: Available values : available, pending, sold
            Console.WriteLine("Find pets by status: available");
            var filterPetByStatus = await PetRestSharpClient.FindPetsByStatus(PetStatus.available);
            Console.WriteLine(filterPetByStatus.StatusCode == System.Net.HttpStatusCode.OK
                   ? "Successfully uploaded Pet Image." : "Image not found.");

            // 8. Confirm deletion
            Console.WriteLine("Verifying Deletion...");
            var getAfterDelete = await PetRestSharpClient.GetPet(newPet.id);
            Console.WriteLine(getAfterDelete.StatusCode == System.Net.HttpStatusCode.NotFound
                ? "Pet successfully deleted."
                : "Pet still exists.");
        }

       
        
    }
}


