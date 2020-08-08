using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HeroesApi.Models
{
    public class Heroe
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("location")]
        public string location { get; set; }

        [JsonPropertyName("popularity")]
        public string Popularity { get; set; }

        [JsonPropertyName("rating")]
        public string Rating { get; set; }

        [JsonPropertyName("profile")]
        public HeroeProfile Profile { get; set; }

        [JsonPropertyName("powers")]
        public IList<HeroePower>  Powers { get; set; }

        [JsonPropertyName("skills")]
        public IList<HeroeSkill>  Skills { get; set; }
    }

    public class HeroeProfile
    {
        [JsonPropertyName("pic")]
        public string Pic { get; set; }

        [JsonPropertyName("firstseen")]
        public string Firstseen { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("background")]
        public string Background { get; set; }
    }

    public class HeroePower
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class HeroeSkill
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}