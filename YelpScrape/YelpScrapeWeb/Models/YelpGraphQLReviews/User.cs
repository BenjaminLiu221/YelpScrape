using System.Text.Json.Serialization;

namespace YelpScrapeWeb.Models.YelpGraphQLReviews
{
    public class User
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
