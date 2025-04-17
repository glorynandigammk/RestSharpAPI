using RestSharpAPI.Models;
using RestSharpAPI.RestSharp;
using System;
using System.Threading.Tasks;

namespace RestSharpAPI.AutomationRunner
{
    public class RestSharpAutomationRunner
    {
        public static async Task RunPetAutomation()
        {
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

            // 3. Update the Pet
            newPet.name = "FluffyUpdated";
            newPet.status = PetStatus.sold.ToString();
            Console.WriteLine("Updating Pet...");
            var updateResponse = await PetRestSharpClient.UpdatePet(newPet);
            Console.WriteLine($"Update Status: {updateResponse.StatusCode}");

            // 4. Get again to confirm update
            var getUpdatedResponse = await PetRestSharpClient.GetPet(newPet.id);
            Console.WriteLine($"Updated Pet: {getUpdatedResponse.Data?.name}, Status: {getUpdatedResponse.Data?.status}");

            // 5. Delete the Pet
            Console.WriteLine("Deleting Pet...");
            var deleteResponse = await PetRestSharpClient.DeletePet(newPet.id);
            Console.WriteLine($"Delete Status: {deleteResponse.StatusCode}");

            // 6. Confirm deletion
            Console.WriteLine("Verifying Deletion...");
            var getAfterDelete = await PetRestSharpClient.GetPet(newPet.id);
            Console.WriteLine(getAfterDelete.StatusCode == System.Net.HttpStatusCode.NotFound
                ? "Pet successfully deleted."
                : "Pet still exists.");

            // 7. Upload Image
            Console.WriteLine("Upload Image...");
            var resposeAfterImageUpload = await PetRestSharpClient.UploadImage(newPet.id);
            Console.WriteLine(resposeAfterImageUpload.StatusCode == System.Net.HttpStatusCode.OK
                   ? "Successfully uploaded Pet Image." : "Image not found.");

            //8. Find pets by Status: Available values : available, pending, sold
            Console.WriteLine("Find pets by status: available");
            var filterPetByStatus = await PetRestSharpClient.FindPetsByStatus(PetStatus.available);
            Console.WriteLine(filterPetByStatus.StatusCode == System.Net.HttpStatusCode.OK
                   ? "Successfully uploaded Pet Image." : "Image not found.");
        }

        public static async Task RunUserAutomation()
        {
            Console.WriteLine("----- USER AUTOMATION -----");

            var user = new User
            {
                Id = 1001,
                Username = "johndoe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password123",
                Phone = "1234567890",
                UserStatus = 1
            };

            // 1. Create User
            Console.WriteLine("Creating User...");
            var createUserResponse = await RestSharpApiClient.CreateUser(user);
            Console.WriteLine($"Create User Status: {createUserResponse.StatusCode}");

            // 2. Get User
            var getUserResponse = await RestSharpApiClient.GetUser(user.Username);
            Console.WriteLine($"User Retrieved: {getUserResponse.Data?.Username}");

            // 3. Update User
            user.FirstName = "Johnny";
            var updateUserResponse = await RestSharpApiClient.UpdateUser(user.Username, user);
            Console.WriteLine($"Update User Status: {updateUserResponse.StatusCode}");

            // 4. Confirm Update
            var updatedUser = await RestSharpApiClient.GetUser(user.Username);
            Console.WriteLine($"Updated User FirstName: {updatedUser.Data?.FirstName}");

            // 5. Delete User
            var deleteUserResponse = await RestSharpApiClient.DeleteUser(user.Username);
            Console.WriteLine($"Delete User Status: {deleteUserResponse.StatusCode}");

        }

        public static async Task RunOrderAutomation()
        {
            Console.WriteLine("----- ORDER AUTOMATION -----");

            var order = new Order
            {
                Id = 2002,
                PetId = 1, // Use an existing PetId
                Quantity = 1,
                ShipDate = DateTime.UtcNow.ToString(),
                Status = "placed",
                Complete = true
            };

            // 1. Place Order
            var placeOrderResponse = await RestSharpApiClient.PlaceOrder(order);
            Console.WriteLine($"Place Order Status: {placeOrderResponse.StatusCode}");

            // 2. Get Order
            var getOrderResponse = await RestSharpApiClient.GetOrder(order.Id);
            Console.WriteLine($"Order Retrieved: {getOrderResponse.Data?.Id}, Status: {getOrderResponse.Data?.Status}");

            // 3. Delete Order
            var deleteOrderResponse = await RestSharpApiClient.DeleteOrder(order.Id);
            Console.WriteLine($"Delete Order Status: {deleteOrderResponse.StatusCode}");

            // 4. Confirm Deletion
            var confirmDeleteOrder = await RestSharpApiClient.GetOrder(order.Id);
            Console.WriteLine(confirmDeleteOrder.StatusCode == System.Net.HttpStatusCode.NotFound
                ? "Order successfully deleted."
                : "Order still exists.");
        }
    }
}


