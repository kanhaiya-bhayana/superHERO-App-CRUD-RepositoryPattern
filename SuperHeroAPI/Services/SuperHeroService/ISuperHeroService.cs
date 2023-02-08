﻿using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetAllSuperHeros();
        SuperHero? GetSingleHero(int id);
        List<SuperHero> AddHero(SuperHero objSuperHero);
        List<SuperHero>? UpdateHero(int id, SuperHero request);
        List<SuperHero>? DeleteHero(int id);



    }
}