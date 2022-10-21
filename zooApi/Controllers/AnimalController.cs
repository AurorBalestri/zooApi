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

        [HttpDelete()]
        public IActionResult RemoveAnimal(int id)
        {
            return Ok(_animalService.RemoveAnimal(id));
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
    }
}
