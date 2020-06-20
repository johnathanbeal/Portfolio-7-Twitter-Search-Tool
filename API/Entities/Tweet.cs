using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ikkyo.Entities
{
    public class Tweet
    {
        public Tweet()
        {

        }

        public Tweet(List<Status> _status, SearchMetadata _searchMetadata)
        {
            Statuses = _status;
            SearchMetadata = _searchMetadata;
        }

        [JsonProperty("statuses")]
        public List<Status> Statuses { get; set; }

        [JsonProperty("search_metadata")]
        public SearchMetadata SearchMetadata { get; set; }
    }
        public class SearchMetadata
        {
            public SearchMetadata()
            {

            }

            [JsonProperty("completed_in")]
            public double CompletedIn { get; set; }

            [JsonProperty("max_id")]
            public double MaxId { get; set; }

            [JsonProperty("max_id_str")]
            public string MaxIdStr { get; set; }

            [JsonProperty("next_results")]
            public string NextResults { get; set; }

            [JsonProperty("query")]
            public string Query { get; set; }

            [JsonProperty("refresh_url")]
            public string RefreshUrl { get; set; }

            [JsonProperty("count")]
            public long Count { get; set; }

            [JsonProperty("since_id")]
            public long SinceId { get; set; }

        }

        public class Status
        {
            public Status()
            {

            }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("id")]
            public double Id { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }
            
            [JsonProperty("retweet_count")]
            public long RetweetCount { get; set; }

            [JsonProperty("favorite_count")]
            public long FavoriteCount { get; set; }

            [JsonProperty("retweeted")]
            public bool Retweeted { get; set; }

        }
    
}

