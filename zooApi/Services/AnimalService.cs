using zooApi.Models;
using zooApi.Services.Interfaces;

namespace zooApi.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IList<Animal> _animals;
        public AnimalService(IList<Animal> animals)
        {
            _animals = animals;
        }

        public Animal AddAnimal(AnimalModelForClient animal)
        {
            var animalToAdd = MappingWithId(animal);
            _animals.Add(animalToAdd);
            return animalToAdd;
        }

        public Animal MappingWithId(AnimalModelForClient animalModel)
        {
            var animalWithId = new Animal();
            animalWithId.Id = GetId();
            animalWithId.Species = animalModel.Species;
            animalWithId.Weight = animalModel.Weight;
            animalWithId.Height = animalModel.Height;

            return animalWithId;
        }

        private int GetId()
        {
            if (_animals.Count == 0)
                return 1;

            return _animals.Max(animal => animal.Id) + 1;
        }

        public Animal RemoveAnimal(int id)
        {
            var animalToDelete = _animals.FirstOrDefault(animal => animal.Id == id);
            if(animalToDelete == null)
            {
                return null;
            } else
            {
                _animals.Remove(animalToDelete);
                return animalToDelete;
            }

        }
    }
}