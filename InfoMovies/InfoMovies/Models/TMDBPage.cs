using Newtonsoft.Json;

namespace InfoMovies.Models
{
    public class TMDbPage
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public TMDbMovie[] Results { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}