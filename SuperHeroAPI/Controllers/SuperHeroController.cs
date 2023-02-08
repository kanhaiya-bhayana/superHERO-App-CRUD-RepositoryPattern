using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly SuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService) {

            _superHeroService  = (SuperHeroService)superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            return await _superHeroService.GetAllSuperHeros();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = await _superHeroService.GetSingleHero(id);
            if (result is null)
                return NotFound("Hero not found.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero objSuperHero)
        {
           var result = await _superHeroService.AddHero(objSuperHero);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id,SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(id, request);
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }

        [HttpDelete("id")] 
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
           var result = await _superHeroService.DeleteHero(id); 
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }
    }
}
