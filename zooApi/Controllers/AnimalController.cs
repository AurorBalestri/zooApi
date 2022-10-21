using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zooApi.Models;
using zooApi.Services;
using zooApi.Services.Interfaces;

namespace zooApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
    private readonly IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
        [HttpPost()]
        public IActionResult CreateAnimal([FromBody] AnimalModelForClient animalModel)
        {
            var animalToAdd = _animalService.AddAnimal(animalModel);
            return Created("", animalToAdd);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveAnimal(int id)
        {
            var animalOnId = _animalService.Remove(id);
            if(animalOnId == null)
            {
                return NoContent();
            } else
            {
                return Ok(animalOnId);
            }
        }

        [HttpGet()]
        public IActionResult GetAllAnimals()
        {
            var animalsOnFile = _animalService.GetAll();
            if(animalsOnFile == null)
            {
                return NotFound();
            } else
            {
                return Ok(animalsOnFile);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            var animal = _animalService.GetDetail(id);
            if(animal == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(animal);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] AnimalModelForClient animal)
        {
            var animalUpdated = _animalService.PutAnimal(animal, id);
            return Ok(animalUpdated);
        }
    }
}
