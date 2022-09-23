using System.Text.Json.Serialization;

namespace YelpScrapeWeb.Models.YelpGraphQL
{
    public class Search
    {
        [JsonPropertyName("business")]
        public List<Business> business { get; set; }
    }
}
