using RestSharpAPI.Models;
using RestSharpAPI.RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.AutomationRunner
{
    internal class UserAutomationRunner
    {
        public static async Task Run()
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
            var createUserResponse = await UserRestSharpClient.CreateUser(user);
            Console.WriteLine($"Create User Status: {createUserResponse.StatusCode}");

            // 2. Get User
            var getUserResponse = await UserRestSharpClient.GetUser(user.Username);
            Console.WriteLine($"User Retrieved: {getUserResponse.Data?.Username}");

            // 3. Update User
            user.FirstName = "Johnny";
            var updateUserResponse = await UserRestSharpClient.UpdateUser(user.Username, user);
            Console.WriteLine($"Update User Status: {updateUserResponse.StatusCode}");

            // 4. Confirm Update
            var updatedUser = await UserRestSharpClient.GetUser(user.Username);
            Console.WriteLine($"Updated User FirstName: {updatedUser.Data?.FirstName}");

            // 5. Delete User
            var deleteUserResponse = await UserRestSharpClient.DeleteUser(user.Username);
            Console.WriteLine($"Delete User Status: {deleteUserResponse.StatusCode}");

        }

    }
}
