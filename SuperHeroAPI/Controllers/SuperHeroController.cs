using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static List<SuperHero> superHeros = new List<SuperHero>{
                new SuperHero
                {
                    Id = 1,
                    Name = "Spidar Man",
                    FirstName= "Peter",
                    LastName= "Parker",
                    Place = "NYC"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "Iron Man",
                    FirstName= "Tony",
                    LastName= "Stark",
                    Place = "Malibu"
                }

            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            return Ok(superHeros);
        }

        [HttpGet("id")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = superHeros.Find(x => x.Id == id);
            if (hero == null)
            {
                return NotFound("Sorry, but this hero doesn't exist");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero objSuperHero)
        {
            superHeros.Add(objSuperHero);
            return Ok(superHeros);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateHero(int id,SuperHero request)
        {
            var hero = superHeros.Find(x => x.Id == id);
            if (hero == null)
            {
                return NotFound("Sorry, but this hero doesn't exist");
            }
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place= request.Place;

            return Ok(superHeros);
        }
    }
}
