using zooApi.Helper;
using zooApi.Models;
using zooApi.Services.Interfaces;

namespace zooApi.Services
{
    public class AnimalService : IAnimalService
    {
        public static readonly string _animalPath = "Animals.txt";
        private readonly IList<Animal> _animals;
        private AnimalFileHelper _fileAnimal = new AnimalFileHelper();

        public AnimalService(IList<Animal> animals)
        {
            _animals = animals;
        }

        public Animal AddAnimal(AnimalModelForClient animal)
        {
            var animalToAdd = MappingWithId(animal);
            var animals = _fileAnimal.ReadAndDeserialize(_animalPath);
            animals.Add(animalToAdd);
            _fileAnimal.WriteAndSerialize(_animalPath, animals);
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
            var animalsOnFile = _fileAnimal.ReadAndDeserialize(_animalPath);
            if (animalsOnFile.Count == 0)
                return 1;

            return animalsOnFile.Max(animal => animal.Id) + 1;
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

        public List<Animal> GetAll()
        {
            return _fileAnimal.ReadAndDeserialize(_animalPath);
        }

        public Animal? GetDetail(int id)
        {
            var animalRead = _fileAnimal.ReadAndDeserialize(_animalPath);
            var animalOnId = animalRead.FirstOrDefault(animal => animal.Id == id);
            return animalOnId;
        }
    }
}