using System.Text.Json.Serialization;

namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class Search
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("business")]
        public List<Business> business { get; set; }
    }
}
