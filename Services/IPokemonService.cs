using System;
using System.Collections.Generic;
using PokemonApi.Models;

namespace PokemonApi.Services {
    public interface IPokemonService {
        List<Pokemon> Get ();
        Pokemon Create (Pokemon pokemon);
        void Update (int id, Pokemon pokemonIn);
        void Remove (Pokemon pokemonIn);
        void Remove (int id);
    }
}