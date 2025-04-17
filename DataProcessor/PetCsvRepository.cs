using RestSharpAPI.DataProcessor;
using RestSharpAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.DataContext
{
    public class PetCsvRepository:IPetRepository
    {
        private readonly string _filePath;
        private readonly ILogger _logger;

        public PetCsvRepository(string filePath, ILogger logger)
        {
            _filePath = filePath;
            _logger = logger;
        }

        public async Task SavePetAsync(Pet pet)
        {
            var line = $"{pet.id},{pet.name},{pet.status}";
            await Task.Run(() =>
            {
                File.AppendAllLines(_filePath, new[] { line });
            });
            _logger.Log($"Pet saved to CSV: {line}");
        }
        public async Task<List<Pet>> GetAllPetsAsync()
        {
            var pets = new List<Pet>();
            await Task.Run(() =>
            {
                foreach (var line in File.ReadAllLines(_filePath))
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3 && int.TryParse(parts[0], out int id))
                    {
                        PetStatus status = (PetStatus)Enum.Parse(typeof(PetStatus), parts[2], true);
                        pets.Add(new Pet { id = id, name = parts[1], status = status.ToString() });
                    }
                }
            });
            return pets;
        }

        public async Task UpdatePetAsync(int id, Pet updatedPet)
        {
            var pets = await GetAllPetsAsync();
            var index = pets.FindIndex(p => p.id.Equals(id));

            if (index >= 0)
            {
                pets[index] = updatedPet;
                WriteAllPets(pets);
                _logger.Log($"Pet updated: {id} -> {updatedPet.id}, {updatedPet.name}, {updatedPet.status}");
            }
            else
            {
                _logger.Log($"Pet not found for update: {id}");
            }
        }

        public async Task DeletePetAsync(int id)
        {
            var pets = await GetAllPetsAsync();
            int originalCount = pets.Count;
            pets = pets.Where(p => !p.id.Equals(id)).ToList();

            if (pets.Count < originalCount)
            {
                WriteAllPets(pets);
                _logger.Log($"Pet deleted: {id}");
            }
            else
            {
                _logger.Log($"Pet not found for deletion: {id}");
            }
        }

        private void WriteAllPets(List<Pet> pets)
        {
            var lines = pets.Select(p => $"{p.id},{p.name},{p.status}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}
