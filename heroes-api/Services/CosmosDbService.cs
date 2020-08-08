using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

using HeroesApi.Models;


namespace HeroesApi.Services
{
    public class CosmosDbService : ICosmosDbService {

        private Container _container;

        public CosmosDbService( CosmosClient dbClient, string databaseName, string containerName )
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<Heroe>> InitializeDb()
        {   
            var query = this._container.GetItemQueryIterator<Heroe>(new QueryDefinition("SELECT * FROM c"));
            
            List<Heroe> results = new List<Heroe>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                
                results.AddRange(response.ToList());
            }

            if(results.Count() <= 0)
                await this.LoadInitialItems();

            return results;
        }

        public async Task LoadInitialItems()
        {
            dynamic heroeSource;

            try
            {
                heroeSource = File.ReadAllText("./assets/hero-profile-dm.json");
            }
            catch (System.Exception)
            {
                
                throw ;
            }

            /*
            var options = new JsonSerializerOptions {
                WriteIndented = true
            };
            */

            IList<Heroe> dataSet = JsonSerializer.Deserialize<IList<Heroe>>(heroeSource);

            foreach (Heroe heroe in dataSet)
            {
                heroe.id = heroe.id.ToLower();
                Console.WriteLine("Creating item for: " + heroe.id);
                await this._container.CreateItemAsync<Heroe>(heroe, new PartitionKey(heroe.location));
            }

        }

        public async Task<IEnumerable<Heroe>> GetHeroList()
        {
            var query = this._container.GetItemQueryIterator<Heroe>(
                                    new QueryDefinition("SELECT * FROM c"));

            List<Heroe> results = new List<Heroe>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                
                results.AddRange(response.ToList());
            }

            return results;

        }
        
    }
}


