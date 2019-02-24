using Newtonsoft.Json;

namespace MovieSearch.Models.ThirdParty
{
    public class MovieDBSearchResponse
    {
        public int Page { get; set; }

        [JsonProperty("results")]
        public MovieDBSearchResult[] Results { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
