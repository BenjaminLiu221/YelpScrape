using System.Text.Json.Serialization;

namespace YelpScrapeWeb.Models.YelpGraphQL
{
    public class Business
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
