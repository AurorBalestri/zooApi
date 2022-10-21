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
            public IActionResult CreateAnimal([FromBody] PostAnimalModel animalModel)
            {
                var animalToAdd = _animalService.AddAnimal(animalModel);
                return Ok(animalToAdd);
            }
        }
}
