using RestSharpAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.DataProcessor
{
    public interface IPetRepository
    {
        Task SavePetAsync(Pet pet);
        Task<List<Pet>> GetAllPetsAsync();
        Task UpdatePetAsync(int id, Pet updatedPet);
        Task DeletePetAsync(int id);
    }
}
