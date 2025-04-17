using RestSharpAPI.DataContext;
using RestSharpAPI.Models;

namespace RestSharpAPI.API
{
    public class PetController
    {
        private readonly PetCsvRepository _repo;

        public PetController(PetCsvRepository repo)
        {
            _repo = repo;
        }

        private readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://petstore.swagger.io/v2/") };

        // Pet endpoints
        public async Task CreatePetAsync(Pet pet)
        {
            await _repo.SavePetAsync(pet);
        }

        public async Task<List<Pet>> GetAllPetAsync()
        {
            return await _repo.GetAllPetsAsync();
        }

        public async Task UpdatePetAsync(int id, Pet pet)
        {
            await _repo.UpdatePetAsync(id, pet);
        }

        public async Task DeletePetAsync(int id)
        {
            await _repo.DeletePetAsync(id);
        }
    }
}
