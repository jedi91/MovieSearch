using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSearch.Settings
{
    public class SearchSettings
    {
        public string MovieDBApiKey { get; set; }

        public string MovieDBBaseUrl { get; set; }

        public string MovieDBImageUrl { get; set; }

        public string PageQueryParam { get; set; }

        public string QueryQueryParam { get; set; }
    }
}
