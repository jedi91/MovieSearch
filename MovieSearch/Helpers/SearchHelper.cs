using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MovieSearch.Models;
using MovieSearch.Models.ThirdParty;
using MovieSearch.Settings;
using System;
using System.Collections.Generic;

namespace MovieSearch.Helpers
{
    public class SearchHelper : ISearchHelper
    {
        private readonly SearchSettings _settings;

        public SearchHelper(IOptionsSnapshot<SearchSettings> options)
        {
            _settings = options.Value;
        }

        public int GetPageFromQueryCollection(IQueryCollection query)
        {
            return Convert.ToInt32(query[_settings.PageQueryParam]);
        }

        public string GetQueryFromQueryCollection(IQueryCollection query)
        {
            return query[_settings.QueryQueryParam];
        }

        public string GetMovieDBApiKey()
        {
            return _settings.MovieDBApiKey;
        }

        public MovieSearchResponse MapMovieDBResponseToResponse(MovieDBSearchResponse response)
        {
            return new MovieSearchResponse()
            {
                Page = response.Page,
                Results = MapMovieDBResultsToResults(response.Results),
            };
        }

        private List<MovieSearchResult> MapMovieDBResultsToResults(
            IEnumerable<MovieDBSearchResult> results)
        {
            var mappedResults = new List<MovieSearchResult>();
            foreach (var result in results)
            {
                mappedResults.Add(
                    new MovieSearchResult()
                    {
                        Title = result.Title,
                        Overview = result.Overview,
                        PosterPath = FormatImageUrl(result.PosterPath),
                        ReleaseDate = FormatReleaseDate(result.ReleaseDate),
                    }
                );
            }

            return mappedResults;
        }

        private string FormatReleaseDate(string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime date))
            {
                return date.ToString("MM/dd/yyyy");
            }

            return "Not Available";
        }

        private string FormatImageUrl(string url)
        {
            return $"{_settings.MovieDBImageUrl}{url}";
        }
    }
}
