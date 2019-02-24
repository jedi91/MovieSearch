using MovieSearch.Models.ThirdParty;
using Refit;
using System.Threading.Tasks;

namespace MovieSearch.RestInterfaces
{
    public interface IMovieDBRestInterface
    {
        [Get("/movie")]
        Task<MovieDBSearchResponse> Search(
            string api_Key,
            string query,
            int page,
            string language,
            int year,
            int primary_release_year,
            string region,
            bool include_adult
        );

        [Get("/movie")]
        Task<MovieDBSearchResponse> Search(
            string api_key,
            string query,
            int page,
            bool include_adult = false
        );
    }
}
