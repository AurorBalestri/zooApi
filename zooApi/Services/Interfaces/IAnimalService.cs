using global::zooApi.Models;
using zooApi.Models;

namespace zooApi.Services.Interfaces
{
    public interface IAnimalService
    {
        public Animal AddAnimal(AnimalModelForClient postAnimal);

        public Animal Remove(int id);

        public List<Animal> GetAll();

        public Animal? GetDetail(int id);

        public Animal PutAnimal(AnimalModelForClient animal, int id);

    }
}
