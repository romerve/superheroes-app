using System.Collections.Generic;
using System.Threading.Tasks;
using HeroesApi.Models;

namespace HeroesApi.Services
{
    public interface ICosmosDbService {

        Task<IEnumerable<Heroe>> InitializeDb();
        Task<IEnumerable<Heroe>> GetHeroList();

    }
    
}