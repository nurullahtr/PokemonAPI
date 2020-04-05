using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using PokemonApi.Models;

namespace PokemonApi.Services {
    public class PokemonService : IPokemonService {

        private readonly IMongoCollection<Pokemon> _pokemons;

        public PokemonService (IPokemonDatabaseSettings settings) {
            var client = new MongoClient (settings.ConnectionString);
            var database = client.GetDatabase (settings.DatabaseName);

            _pokemons = database.GetCollection<Pokemon> (settings.PokemonCollectionName);
        }

        public List<Pokemon> Get () =>
            _pokemons.Find (pokemon => true).ToList ();

        public Pokemon Get (int id) =>
            _pokemons.Find<Pokemon> (pokemon => pokemon.id == id).FirstOrDefault ();

        public Pokemon Create (Pokemon pokemon) {
            _pokemons.InsertOne (pokemon);
            return pokemon;
        }

        public void Update (int id, Pokemon pokemonIn) =>
            _pokemons.ReplaceOne (pokemon => pokemon.id == id, pokemonIn);

        public void Remove (Pokemon pokemonIn) =>
            _pokemons.DeleteOne (pokemon => pokemon.id == pokemonIn.id);

        public void Remove (int id) =>
            _pokemons.DeleteOne (pokemon => pokemon.id == id);

    }
}