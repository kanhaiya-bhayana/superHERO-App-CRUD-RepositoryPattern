namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
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
        public List<SuperHero> AddHero(SuperHero objSuperHero)
        {
            superHeros.Add(objSuperHero);
            return superHeros;
        }

        public List<SuperHero>? DeleteHero(int id)
        {
            var hero = superHeros.Find(x => x.Id == id);
            if (hero is null)
                return null;
            superHeros.Remove(hero);
            return superHeros;
        }

        public List<SuperHero> GetAllSuperHeros()
        {
            return superHeros;
        }

        public SuperHero? GetSingleHero(int id)
        {
            var hero = superHeros.Find(x => x.Id == id);
            if (hero is null)
                return null;
            return hero;
        }

        public List<SuperHero>? UpdateHero(int id, SuperHero request)
        {
            var hero = superHeros.Find(x => x.Id == id);
            if (hero is null)
                return null;
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return superHeros;
        }
    }
}
