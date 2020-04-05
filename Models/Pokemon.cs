using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokemonApi.Models {
    public class Pokemon {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string _id { get; set; }
        public int id { get; set; }
        public string num { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public List<string> type { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string candy { get; set; }
        public int candy_count { get; set; }
        public string egg { get; set; }
        public double spawn_chance { get; set; }
        public double avg_spawns { get; set; }
        public string spawn_time { get; set; }
        public List<double> multipliers { get; set; }
        public List<string> weaknesses { get; set; }
        public List<PrevEvolution> prev_evolution { get; set; }
        public List<NextEvolution> next_evolution { get; set; }
    }

    public class PrevEvolution {
        public string num { get; set; }
        public string name { get; set; }
    }

    public class NextEvolution {
        public string num { get; set; }
        public string name { get; set; }
    }
}