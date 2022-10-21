using global::zooApi.Models;
using zooApi.Models;

namespace zooApi.Services.Interfaces
{
    public interface IAnimalService
    {
        public Animal AddAnimal(AnimalModelForClient postAnimal);

        public Animal RemoveAnimal(int id);

        public List<Animal> GetAll();

    }
}
