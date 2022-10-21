using global::zooApi.Models;
using zooApi.Models;

namespace zooApi.Services.Interfaces
{
    public interface IAnimalService
    {
        public Animal AddAnimal(PostAnimalModel postAnimal);
    }
}
