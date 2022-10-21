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

        public Animal AddAnimal(PostAnimalModel animal)
        {
            var animalToAdd = MappingWithId(animal);
            _animals.Add(animalToAdd);
            return animalToAdd;
        }

        public Animal MappingWithId(PostAnimalModel animalModel)
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
    }
}