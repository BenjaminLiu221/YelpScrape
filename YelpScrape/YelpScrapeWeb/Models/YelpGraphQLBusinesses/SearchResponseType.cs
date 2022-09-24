using System.Text.Json.Serialization;

namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class SearchResponseType
    {
        [JsonPropertyName("search")]
        public Search Search { get; set; }
    }
}
