using RestSharpAPI.API;
using RestSharpAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.UI
{
    public class PetApp
    {
        private readonly PetController _controller;

        public PetApp(PetController controller)
        {
            _controller = controller;
        }

        public Pet Create()
        {
            Console.WriteLine("🐾 Welcome to Pet Creator 🐾");
            Console.Write("Enter pet id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter pet name: ");
            string name = Console.ReadLine();

            Console.Write("Enter pet status: ");
            string status = Console.ReadLine();
            PetStatus statusEnum = (PetStatus)Enum.Parse(typeof(PetStatus), status, true);

            var pet = new Pet { id = id, name = name, status = statusEnum.ToString() };
             Task.Run(async() => await _controller.CreatePetAsync(pet));

            Console.WriteLine("✅ Pet created successfully!");
            return pet;
        }

        public void GetAllPets() {
            Console.WriteLine("🐾 All Pets:🐾");
            var pets = _controller.GetAllPetAsync();
            foreach (var pet in pets.Result)
            {
                Console.WriteLine($"{pet.id},{pet.name},{pet.status}");
            }
        }

        public void UpdatePet(int id, Pet pet)
        {
            Task.Run(async()=> await _controller.UpdatePetAsync(id,pet));
            Console.WriteLine($"{pet.id},{pet.name},{pet.status}");
        }

        public void DeletePet(int id)
        {
            Task.Run(async () => await _controller.DeletePetAsync(id));
            Console.WriteLine($"Pet Id deleted: {id}");
        }

    }
}
