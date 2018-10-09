using Newtonsoft.Json;

namespace InfoMovies.Models
{
    public class TMDbGenreCollection
    {
        [JsonProperty("genres")]
        public TMDbGenre[] Genres { get; set; }
    }

    public class TMDbGenre
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
