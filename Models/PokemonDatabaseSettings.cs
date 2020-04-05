namespace PokemonApi.Models
{
    public class PokemonDatabaseSettings : IPokemonDatabaseSettings
    {
        public string PokemonCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPokemonDatabaseSettings
    {
        string PokemonCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}