using System.Collections.Generic;

namespace MovieSearch.Models
{
    public class MovieSearchResponse
    {
        public int Page { get; set; }

        public List<MovieSearchResult> Results { get; set; }
    }
}
