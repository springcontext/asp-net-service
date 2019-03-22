using AspConsumer.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspConsumer.Repositories
{
    public interface IHeroRepository
    {
        IEnumerable<Hero> GetHeroes();
        Hero GetHero(Guid id);
        void AddHero(Hero hero);
        void DeleteHero(Hero hero);
    }
}
