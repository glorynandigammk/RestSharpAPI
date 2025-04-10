﻿// PET TEST
using RestSharpAPI;
using RestSharpAPI.API;
using RestSharpAPI.Models;

var pet = new Pet { Id = 112233, Name = "Buddy", Status = "available" };
await PetApiClient.CreatePetAsync(pet);
var fetchedPet = await PetApiClient.GetPetAsync(pet.Id);
pet.Status = "sold";
await PetApiClient.UpdatePetAsync(pet);
await PetApiClient.DeletePetAsync(pet.Id);

// ORDER TEST
var order = new Order { Id = 12345, PetId = 112233, Quantity = 1, ShipDate = DateTime.UtcNow.ToString("o"), Status = "placed", Complete = true };
await OrderApiClient.PlaceOrderAsync(order);
var fetchedOrder = await OrderApiClient.GetOrderAsync(order.Id);
await OrderApiClient.DeleteOrderAsync(order.Id);

// USER TEST
var user = new User { Id = 1, Username = "testuser", FirstName = "Test", LastName = "User", Email = "test@user.com", Password = "pass123", Phone = "1234567890", UserStatus = 1 };
await UserApiClient.CreateUserAsync(user);
var fetchedUser = await UserApiClient.GetUserAsync(user.Username);
user.FirstName = "Updated";
await UserApiClient.UpdateUserAsync(user.Username, user);
await UserApiClient.DeleteUserAsync(user.Username);