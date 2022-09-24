using System.Text.Json.Serialization;

namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class Search
    {
        [JsonPropertyName("business")]
        public List<Business> business { get; set; }
    }
}
