// PET TEST
using RestSharpAPI.API;
using RestSharpAPI.AutomationRunner;
using RestSharpAPI.DataContext;
using RestSharpAPI.Models;
using RestSharpAPI.TestAssertions;
using RestSharpAPI.UI;
using RestSharpAPI.Utilities;

await RestSharpAutomationRunner.RunPetAutomation();
//await RestSharpAutomationRunner.RunUserAutomation();
//await RestSharpAutomationRunner.RunOrderAutomation();


//ILogger logger = new ConsoleLogger();
//var petRepository = new PetCsvRepository("pets.csv", logger);
//var controller = new PetController(petRepository);
//var petapp = new PetApp(controller);

//var pet1 = petapp.Create();
//bool confirm = DisplayHelper.GetYesOrNo("Would you like to create another pet?");
//if (confirm)
//{
//    var pet2 = petapp.Create();
//}
//confirm = DisplayHelper.GetYesOrNo("Would you like to create another pet?");
//if (confirm)
//{
//    var pet3 = petapp.Create();
//}

//petapp.GetAllPets();

//petapp.UpdatePet(pet1.Id, new Pet {Id=pet1.Id, Name = "Pet1NameChanged",Status="Updated"});
//petapp.DeletePet(pet1.Id);
//petapp.GetAllPets();


// ORDER TEST
//var order = new Order { Id = 12345, PetId = 112233, Quantity = 1, ShipDate = DateTime.UtcNow.ToString("o"), Status = "placed", Complete = true };
//await OrderApiClient.PlaceOrderAsync(order);
//var fetchedOrder = await OrderApiClient.GetOrderAsync(order.Id);
//if (fetchedOrder != null) TestAssertions.AssertOrderEqual(order, fetchedOrder);

//await OrderApiClient.DeleteOrderAsync(order.Id);

//// USER TEST
//var user = new User { Id = 1, Username = "testuser", FirstName = "Test", LastName = "User", Email = "test@user.com", Password = "pass123", Phone = "1234567890", UserStatus = 1 };
//await UserApiClient.CreateUserAsync(user);
//var fetchedUser = await UserApiClient.GetUserAsync(user.Username);
//if (fetchedUser != null) TestAssertions.AssertUserEqual(user, fetchedUser);

//user.FirstName = "Updated";
//await UserApiClient.UpdateUserAsync(user.Username, user);
//await UserApiClient.DeleteUserAsync(user.Username);





