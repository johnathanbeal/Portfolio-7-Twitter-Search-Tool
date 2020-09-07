using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Tweet
    {
        public Tweet()
        {
            Statuses = new List<Status>();
            SearchMetadata = new SearchMetadata();
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

    }

    public class Status
    {
        public Status()
        {
            
        }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("entities")]
        public Entities Entities { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

    }


    public class Entities
    {
        public Entities()
        {
            Media = new List<Medium>();
        }
    
        [JsonProperty("media")]
        public List<Medium> Media { get; set; }
    }

    public class Medium
    {
        public Medium()
        {
          
        }
 
        [JsonProperty("media_url")]
        public string media_url { get; set; }
    }

    public class User
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("screen_name")]
        public string screen_name { get; set; }

        [JsonProperty("location")]
        public string location { get; set; }

        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }
    }
}

