using Microsoft.AspNetCore.Http;
using MovieSearch.Models;
using MovieSearch.Models.ThirdParty;

namespace MovieSearch.Helpers
{
    public interface ISearchHelper
    {
        int GetPageFromQueryCollection(IQueryCollection query);

        string GetQueryFromQueryCollection(IQueryCollection query);

        string GetMovieDBApiKey();

        MovieSearchResponse MapMovieDBResponseToResponse(MovieDBSearchResponse response);
    }
}
