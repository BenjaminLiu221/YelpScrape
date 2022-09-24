using System.Text.Json.Serialization;

namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class Business
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
