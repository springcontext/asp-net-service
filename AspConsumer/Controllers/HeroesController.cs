using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspConsumer.Domains.Entities;
using AspConsumer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private IHeroService _service;

        private readonly ILogger _logger;

        public HeroesController(IHeroService heroService, ILoggerFactory loggerFactory)
        {
            _service = heroService;
            _logger = loggerFactory.CreateLogger("Logging");
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Hero> GetHeroes()
        {
            _logger.LogInformation("Fetch all heroes");
            return _service.FindHeroes();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void CreateHero([FromBody] Hero h)
        {
            _logger.LogInformation("Create hero with name = " + h.Name);
            Hero hero = new Hero
            {
                Name = h.Name
            };
            _service.CreateHero(hero);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
