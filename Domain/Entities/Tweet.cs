using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data.Common;

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

        //[JsonProperty("completed_in")]
        //public double CompletedIn { get; set; }

        //[JsonProperty("max_id")]
        //public double MaxId { get; set; }

        //[JsonProperty("max_id_str")]
        //public string MaxIdStr { get; set; }

        //[JsonProperty("next_results")]
        //public string NextResults { get; set; }

        //[JsonProperty("query")]
        //public string Query { get; set; }

        //[JsonProperty("refresh_url")]
        //public string RefreshUrl { get; set; }

        //[JsonProperty("count")]
        //public long Count { get; set; }

        //[JsonProperty("since_id")]
        //public long SinceId { get; set; }

    }

    public class Status
    {
        public Status()
        {
            //User = new User();
            //Entities = new Entities();
        }

        //[JsonProperty("created_at")]
        //public string CreatedAt { get; set; }

        //[JsonProperty("id")]
        //public double Id { get; set; }

        //[JsonProperty("id_str")]
        //public string IdString { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        //[JsonProperty("truncated")]
        //public string Truncated { get; set; }

        [JsonProperty("entities")]
        public Entities Entities { get; set; }

        //[JsonProperty("metadata")]
        //public Metadata Metadata { get; set; }

        //[JsonProperty("source")]
        //public string Source { get; set; }

        //[JsonProperty("in_reply_to_status_id")]
        //public Metadata InReplyToStatusId { get; set; }

        //[JsonProperty("in_reply_to_status_id_str")]
        //public Metadata InReplyToStatusIdStr { get; set; }

        //[JsonProperty("in_reply_to_user_id")]
        //public Metadata InReplyToUserId { get; set; }

        //[JsonProperty("in_reply_to_user_id_str")]
        //public Metadata InReplyToUserIdStr { get; set; }

        //[JsonProperty("in_reply_to_screen_name")]
        //public Metadata InReplyToScreenName { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        //[JsonProperty("geo")]
        //public string Geo { get; set; }

        //[JsonProperty("coordinates")]
        //public object Coordinates { get; set; }

        //[JsonProperty("place")]
        //public object Place { get; set; }

        //[JsonProperty("contributors")]
        //public object Contributors { get; set; }

        //[JsonProperty("retweeted_status")]
        //public long RetweetedStatus { get; set; }

        //[JsonProperty("is_quote_status")]
        //public long IsQuoteStatus { get; set; }

        //[JsonProperty("retweet_count")]
        //public long RetweetCount { get; set; }

        //[JsonProperty("favorite_count")]
        //public long FavoriteCount { get; set; }

        //[JsonProperty("favorited")]
        //public bool Favorited { get; set; }

        //[JsonProperty("retweeted")]
        //public bool Retweeted { get; set; }

        //[JsonProperty("lang")]
        //public string Lang { get; set; }

    }


    //public class User_mentionsItem
    //{

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("screen_name")]
        //public string ScreenName { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("name")]
        //public string Name { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("id")]
        //public int Id { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("id_str")]
        //public string IdStr { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("indices")]
        //public List<int> Indices { get; set; }
    //}

    public class Entities
    {
        public Entities()
        {
            //Media = new List<Media>();
            Media = new List<Medium>();
            
        }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("hashtags")]
        //public List<string> hashtags { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("symbolds")]
        //public List<string> symbols { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("user_mentions")]
        //public List<User_mentionsItem> user_mentions { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("urls")]
        //public List<string> urls { get; set; }

        [JsonProperty("media")]
        public List<Medium> Media { get; set; }
    }

    public class Medium
    {
        public Medium()
        {
          
        }
        //public long id { get; set; }
        //public string id_str { get; set; }
        //public List<int> indices { get; set; }

        [JsonProperty("media_url")]
        public string media_url { get; set; }

        //public string media_url_https { get; set; }
        //public string url { get; set; }
        //public string display_url { get; set; }
        //public string expanded_url { get; set; }
        //public string type { get; set; }
        ////public Sizes sizes { get; set; }
        //public long source_status_id { get; set; }
        //public string source_status_id_str { get; set; }
        //public long source_user_id { get; set; }
        //public string source_user_id_str { get; set; }
    }

    //public class Media
    //{
    //    //[JsonProperty("id")]
    //    //public string Id { get; set; }

    //    //[JsonProperty("id_str")]
    //    //public string IdString { get; set; }
                        
    //    //[JsonProperty("indices")]
    //    //public List<int> Indices { get; set; }

    //    [JsonProperty("media_url")]
    //    public Uri MediaUrl { get; set; }

    //    //[JsonProperty("media_url_https")]
    //    //public Uri MediaUrlHttps { get; set; }

    //    //[JsonProperty("url")]
    //    //public Uri Url { get; set; }

    //    //[JsonProperty("display_url")]
    //    //public Uri DisplayUrl { get; set; }

    //    //[JsonProperty("expanded_url")]
    //    //public Uri ExpandedUrl { get; set; }

    //    //[JsonProperty("type")]
    //    //public string Type { get; set; }


    //    //"sizes": {
    //    //    "thumb": {
    //    //        "w": 150,
    //    //        "h": 150,
    //    //        "resize": "crop"
    //    //    },
    //    //    "large": {
    //    //        "w": 343,
    //    //        "h": 420,
    //    //        "resize": "fit"
    //    //    },
    //    //    "small": {
    //    //        "w": 343,
    //    //        "h": 420,
    //    //        "resize": "fit"
    //    //    },
    //    //    "medium": {
    //    //        "w": 343,
    //    //        "h": 420,
    //    //        "resize": "fit"
    //    //    }
    //    //}
    //}

    //public class Metadata
    //{

    //    [JsonProperty("iso_language_code")]
    //    public string iso_language_code { get; set; }
        
    //    [JsonProperty("result_type")]
    //    public string result_type { get; set; }
    //}

    //public class UrlsItem
    //{

    //    [JsonProperty("url")]
    //    public string url { get; set; }


    //    [JsonProperty("expanded_url")] 
    //    public string expanded_url { get; set; }

    //    [JsonProperty("display_url")]
    //    public string display_url { get; set; }

    //    [JsonProperty("indices")]
    //    public List<int> indices { get; set; }
    //}

    //public class Url
    //{

    //    [JsonProperty("urls")]
    //    public List<UrlsItem> urls { get; set; }
    //}

    //public class Description
    //{

    //    [JsonProperty("urls")]
    //    public List<string> urls { get; set; }
    //}

    //public class UserEntities
    //{
    //    [JsonProperty("url")]
    //    public Url url { get; set; }

    //    [JsonProperty("description")]
    //    public Description description { get; set; }
    //}

    public class User
    {

        //[JsonProperty("id")]
        //public int id { get; set; }

        //[JsonProperty("id_str")]
        //public string id_str { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("screen_name")]
        public string screen_name { get; set; }

        [JsonProperty("location")]
        public string location { get; set; }

        //[JsonProperty("description")]
        //public string description { get; set; }

        //[JsonProperty("url")]
        //public string url { get; set; }

        //[JsonProperty("entities")]
        //public Entities entities { get; set; }

        //[JsonProperty("protected")]
        //public string Protected { get; set; }

        //[JsonProperty("followers_count")]
        //public int followers_count { get; set; }

        //[JsonProperty("friends_count")]
        //public int friends_count { get; set; }

        //[JsonProperty("listed_count")]
        //public int listed_count { get; set; }

        //[JsonProperty("created_at")]
        //public string created_at { get; set; }

        //[JsonProperty("favourites_count")]
        //public int favourites_count { get; set; }

        //[JsonProperty("utc_offset")]
        //public string utc_offset { get; set; }

        //[JsonProperty("time_zone")]
        //public string time_zone { get; set; }

        //[JsonProperty("geo_enabled")]
        //public string geo_enabled { get; set; }

        //[JsonProperty("verified")]
        //public string verified { get; set; }

        //[JsonProperty("statuses_count")]
        //public int statuses_count { get; set; }

        //[JsonProperty("lang")]
        //public string lang { get; set; }

        //[JsonProperty("contributors_enabled")]
        //public string contributors_enabled { get; set; }

        //[JsonProperty("is_translator")]
        //public string is_translator { get; set; }

        //[JsonProperty("is_translation_enabled")]
        //public string is_translation_enabled { get; set; }

        //[JsonProperty("profile_background_color")]
        //public string profile_background_color { get; set; }

        //[JsonProperty("profile_background_image_url")]
        //public string profile_background_image_url { get; set; }

        //[JsonProperty("profile_background_image_url_https")]
        //public string profile_background_image_url_https { get; set; }

        //[JsonProperty("profile_background_tile")]
        //public string profile_background_tile { get; set; }

        //[JsonProperty("profile_image_url")]
        //public string profile_image_url { get; set; }

        //[JsonProperty("profile_image_url_https")]
        //public string profile_image_url_https { get; set; }

        //[JsonProperty("profile_banner_url")]
        //public string profile_banner_url { get; set; }

        //[JsonProperty("profile_link_color")]
        //public string profile_link_color { get; set; }

        //[JsonProperty("profile_sidebar_border_color")]
        //public string profile_sidebar_border_color { get; set; }

        //[JsonProperty("profile_sidebar_fill_color")]
        //public string profile_sidebar_fill_color { get; set; }

        //[JsonProperty("profile_text_color")]
        //public string profile_text_color { get; set; }

        //[JsonProperty("profile_use_background_image")]
        //public string profile_use_background_image { get; set; }

        //[JsonProperty("has_extended_profile")]
        //public string has_extended_profile { get; set; }

        //[JsonProperty("default_profile")]
        //public string default_profile { get; set; }

        //[JsonProperty("default_profile_image")]
        //public string default_profile_image { get; set; }

        //[JsonProperty("following")]
        //public string following { get; set; }

        //[JsonProperty("follow_request_sent")]
        //public string follow_request_sent { get; set; }

        //[JsonProperty("notifications")]
        //public string notifications { get; set; }

        //[JsonProperty("translator_type")]
        //public string translator_type { get; set; }
    }


}

