using AspConsumer.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspConsumer.Services
{
    public interface IHeroService
    {
        IEnumerable<Hero> FindHeroes();
        Hero FindHero(Guid id);
        void CreateHero(Hero hero);
        void DeleteHero(Hero hero);
    }
}
