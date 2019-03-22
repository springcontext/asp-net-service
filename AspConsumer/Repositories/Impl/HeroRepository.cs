using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspConsumer.Domains.Context;
using AspConsumer.Domains.Entities;

namespace AspConsumer.Repositories.Impl
{
    public class HeroRepository : IHeroRepository
    {
        private HeroContext _context;

        public HeroRepository(HeroContext heroContext)
        {
            _context = heroContext;
        }

        public void AddHero(Hero hero)
        {
            hero.Id = Guid.NewGuid();
            _context.Heroes.Add(hero);
            _context.SaveChanges();
        }

        public void DeleteHero(Hero hero)
        {
            _context.Heroes.Remove(hero);
            _context.SaveChanges();
        }

        public Hero GetHero(Guid id)
        {
            return _context.Heroes.FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<Hero> GetHeroes()
        {
            return _context.Heroes;
        }
    }
}
