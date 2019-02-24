using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using MovieSearch.Helpers;
using MovieSearch.RestInterfaces;
using System;
using Microsoft.Extensions.Options;

namespace MovieSearch.Functions
{
    public class Search
    {
        private readonly ISearchHelper _helper;
        private readonly IMovieDBRestInterface _restInterface;

        public Search(ISearchHelper helper, IMovieDBRestInterface restInterface)
        {
            _helper = helper;
            _restInterface = restInterface;
        }

        [FunctionName(nameof(Search))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            var page = _helper.GetPageFromQueryCollection(req.Query);
            var query = _helper.GetQueryFromQueryCollection(req.Query);
            var apiKey = _helper.GetMovieDBApiKey();

            var response = await _restInterface.Search(apiKey, query, page);
            var mappedResponse = _helper.MapMovieDBResponseToResponse(response);

            req.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return new OkObjectResult(mappedResponse);
        }
    }
}
