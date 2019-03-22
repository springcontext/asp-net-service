using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspConsumer.Domains.Entities;
using AspConsumer.Repositories;

namespace AspConsumer.Services
{
    public class HeroService : IHeroService
    {
        private IHeroRepository _repository;

        public HeroService(IHeroRepository heroRepository)
        {
            _repository = heroRepository;
        }

        public void CreateHero(Hero hero)
        {
            _repository.AddHero(hero);
        }

        public void DeleteHero(Hero hero)
        {
            _repository.DeleteHero(hero);
        }

        public Hero FindHero(Guid id)
        {
            return _repository.GetHero(id);
        }

        public IEnumerable<Hero> FindHeroes()
        {
            return _repository.GetHeroes();
        }
    }
}
