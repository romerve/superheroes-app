using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HeroesApi.Services;

namespace HeroesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SuperHeroesController : ControllerBase
    {
        private readonly ICosmosDbService _cosmosDbService;

        public SuperHeroesController( ICosmosDbService cosmosDbService )
        {
            _cosmosDbService = cosmosDbService;
        }

        [ActionName("index")]
        public async Task Index()
        {
            Console.WriteLine("Beginning operations...\n");

            var q = await _cosmosDbService.InitializeDb();

            Console.WriteLine("######### -: " + q.Count().ToString());
        }

        [ActionName("listheros")]
        public async Task<IActionResult> ListHeros()
        {
            Console.WriteLine("Getting hero list...");
            dynamic hero = await _cosmosDbService.GetHeroList();

            return new OkObjectResult(hero);

        }

        [ActionName("addhero")]
        public async Task<IActionResult> AddHero(dynamic hero)
        {
            Console.WriteLine("Creating hero...");
            await _cosmosDbService.CreateHero(hero.ToString());

            return Ok();
        }
    }
}
