// PET TEST
using RestSharpAPI;

var pet = new Pet { Id = 112233, Name = "Buddy", Status = "available" };
await ApiClient.CreatePetAsync(pet);
var fetchedPet = await ApiClient.GetPetAsync(pet.Id);
pet.Status = "sold";
await ApiClient.UpdatePetAsync(pet);
await ApiClient.DeletePetAsync(pet.Id);

// ORDER TEST
var order = new Order { Id = 12345, PetId = 112233, Quantity = 1, ShipDate = DateTime.UtcNow.ToString("o"), Status = "placed", Complete = true };
await ApiClient.PlaceOrderAsync(order);
var fetchedOrder = await ApiClient.GetOrderAsync(order.Id);
await ApiClient.DeleteOrderAsync(order.Id);

// USER TEST
var user = new User { Id = 1, Username = "testuser", FirstName = "Test", LastName = "User", Email = "test@user.com", Password = "pass123", Phone = "1234567890", UserStatus = 1 };
await ApiClient.CreateUserAsync(user);
var fetchedUser = await ApiClient.GetUserAsync(user.Username);
user.FirstName = "Updated";
await ApiClient.UpdateUserAsync(user.Username, user);
await ApiClient.DeleteUserAsync(user.Username);