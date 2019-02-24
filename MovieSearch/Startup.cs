using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovieSearch;
using MovieSearch.Helpers;
using MovieSearch.RestInterfaces;
using MovieSearch.Settings;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: WebJobsStartup(typeof(Startup))]
namespace MovieSearch
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.Configure<SearchSettings>(config);
            builder.Services.AddTransient<ISearchHelper, SearchHelper>();
            builder.Services.AddTransient((x) =>
            {
                var options = x.GetService<IOptionsSnapshot<SearchSettings>>();
                return RestService.For<IMovieDBRestInterface>(options.Value.MovieDBBaseUrl);
            });
        }
    }
}
