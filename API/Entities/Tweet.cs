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
        
        public partial class Welcome
        {
            [JsonProperty("statuses")]
            public Status[] Statuses { get; set; }

            [JsonProperty("search_metadata")]
            public SearchMetadata SearchMetadata { get; set; }
        }

        public partial class SearchMetadata
        {
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

            [JsonProperty("since_id_str")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long SinceIdStr { get; set; }
        }

        public partial class Status
        {
            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("id")]
            public double Id { get; set; }

            [JsonProperty("id_str")]
            public string IdStr { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("truncated")]
            public bool Truncated { get; set; }

            [JsonProperty("entities")]
            public StatusEntities Entities { get; set; }

            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("in_reply_to_status_id")]
            public object InReplyToStatusId { get; set; }

            [JsonProperty("in_reply_to_status_id_str")]
            public object InReplyToStatusIdStr { get; set; }

            [JsonProperty("in_reply_to_user_id")]
            public object InReplyToUserId { get; set; }

            [JsonProperty("in_reply_to_user_id_str")]
            public object InReplyToUserIdStr { get; set; }

            [JsonProperty("in_reply_to_screen_name")]
            public object InReplyToScreenName { get; set; }

            [JsonProperty("user")]
            public User User { get; set; }

            [JsonProperty("geo")]
            public object Geo { get; set; }

            [JsonProperty("coordinates")]
            public object Coordinates { get; set; }

            [JsonProperty("place")]
            public object Place { get; set; }

            [JsonProperty("contributors")]
            public object Contributors { get; set; }

            [JsonProperty("is_quote_status")]
            public bool IsQuoteStatus { get; set; }

            [JsonProperty("retweet_count")]
            public long RetweetCount { get; set; }

            [JsonProperty("favorite_count")]
            public long FavoriteCount { get; set; }

            [JsonProperty("favorited")]
            public bool Favorited { get; set; }

            [JsonProperty("retweeted")]
            public bool Retweeted { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }
        }

        public partial class StatusEntities
        {
            [JsonProperty("hashtags")]
            public object[] Hashtags { get; set; }

            [JsonProperty("symbols")]
            public object[] Symbols { get; set; }

            [JsonProperty("user_mentions")]
            public object[] UserMentions { get; set; }

            [JsonProperty("urls")]
            public Url[] Urls { get; set; }
        }

        public partial class Url
        {
            [JsonProperty("url")]
            public Uri UrlUrl { get; set; }

            [JsonProperty("expanded_url")]
            public Uri ExpandedUrl { get; set; }

            [JsonProperty("display_url")]
            public string DisplayUrl { get; set; }

            [JsonProperty("indices")]
            public long[] Indices { get; set; }
        }

        public partial class Metadata
        {
            [JsonProperty("result_type")]
            public string ResultType { get; set; }

            [JsonProperty("iso_language_code")]
            public string IsoLanguageCode { get; set; }
        }

        public partial class User
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("id_str")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long IdStr { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("screen_name")]
            public string ScreenName { get; set; }

            [JsonProperty("location")]
            public string Location { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("url")]
            public Uri Url { get; set; }

            [JsonProperty("entities")]
            public UserEntities Entities { get; set; }

            [JsonProperty("protected")]
            public bool Protected { get; set; }

            [JsonProperty("followers_count")]
            public long FollowersCount { get; set; }

            [JsonProperty("friends_count")]
            public long FriendsCount { get; set; }

            [JsonProperty("listed_count")]
            public long ListedCount { get; set; }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("favourites_count")]
            public long FavouritesCount { get; set; }

            [JsonProperty("utc_offset")]
            public object UtcOffset { get; set; }

            [JsonProperty("time_zone")]
            public object TimeZone { get; set; }

            [JsonProperty("geo_enabled")]
            public bool GeoEnabled { get; set; }

            [JsonProperty("verified")]
            public bool Verified { get; set; }

            [JsonProperty("statuses_count")]
            public long StatusesCount { get; set; }

            [JsonProperty("lang")]
            public object Lang { get; set; }

            [JsonProperty("contributors_enabled")]
            public bool ContributorsEnabled { get; set; }

            [JsonProperty("is_translator")]
            public bool IsTranslator { get; set; }

            [JsonProperty("is_translation_enabled")]
            public bool IsTranslationEnabled { get; set; }

            [JsonProperty("profile_background_color")]
            public string ProfileBackgroundColor { get; set; }

            [JsonProperty("profile_background_image_url")]
            public Uri ProfileBackgroundImageUrl { get; set; }

            [JsonProperty("profile_background_image_url_https")]
            public Uri ProfileBackgroundImageUrlHttps { get; set; }

            [JsonProperty("profile_background_tile")]
            public bool ProfileBackgroundTile { get; set; }

            [JsonProperty("profile_image_url")]
            public Uri ProfileImageUrl { get; set; }

            [JsonProperty("profile_image_url_https")]
            public Uri ProfileImageUrlHttps { get; set; }

            [JsonProperty("profile_banner_url")]
            public Uri ProfileBannerUrl { get; set; }

            [JsonProperty("profile_link_color")]
            public string ProfileLinkColor { get; set; }

            [JsonProperty("profile_sidebar_border_color")]
            public string ProfileSidebarBorderColor { get; set; }

            [JsonProperty("profile_sidebar_fill_color")]
            public string ProfileSidebarFillColor { get; set; }

            [JsonProperty("profile_text_color")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long ProfileTextColor { get; set; }

            [JsonProperty("profile_use_background_image")]
            public bool ProfileUseBackgroundImage { get; set; }

            [JsonProperty("has_extended_profile")]
            public bool HasExtendedProfile { get; set; }

            [JsonProperty("default_profile")]
            public bool DefaultProfile { get; set; }

            [JsonProperty("default_profile_image")]
            public bool DefaultProfileImage { get; set; }

            [JsonProperty("following")]
            public object Following { get; set; }

            [JsonProperty("follow_request_sent")]
            public object FollowRequestSent { get; set; }

            [JsonProperty("notifications")]
            public object Notifications { get; set; }

            [JsonProperty("translator_type")]
            public string TranslatorType { get; set; }
        }

        public partial class UserEntities
        {
            [JsonProperty("url")]
            public Description Url { get; set; }

            [JsonProperty("description")]
            public Description Description { get; set; }
        }

        public partial class Description
        {
            [JsonProperty("urls")]
            public Url[] Urls { get; set; }
        }

        public partial class Welcome
        {
            public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Tweet.Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                long l;
                if (Int64.TryParse(value, out l))
                {
                    return l;
                }
                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            public static readonly ParseStringConverter Singleton = new ParseStringConverter();
        }
    }


}

