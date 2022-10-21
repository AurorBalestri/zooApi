using System.Text.Json;
using zooApi.Models;

namespace zooApi.Helper
{
    public class AnimalFileHelper
    {
        private string Serializer(List<Animal> animalsList)
        {
            return JsonSerializer.Serialize(animalsList);
        }

        public void WriteAndSerialize(string path, List<Animal> animals)
        {
            string json = Serializer(animals);
            File.WriteAllText(path, json);
        }

        /*private static List<Animal> Deserialize(string json)
        {
            return JsonSerializer.Deserialize<List<Animal>>(json);
        }*/

        /*public static string Read(string path)
        {
            return File.ReadAllText(path);
        }*/

        public List<Animal> ReadAndDeserialize(string path)
        {
            string json = File.ReadAllText(path);
            if(json == string.Empty)
            {
                return new List<Animal>();
            } else
            {
            List<Animal> animals = JsonSerializer.Deserialize<List<Animal>>(json);
            return animals;
            }
        }
    }
}
