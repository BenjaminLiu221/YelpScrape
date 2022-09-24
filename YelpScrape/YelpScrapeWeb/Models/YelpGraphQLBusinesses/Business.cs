using System.Text.Json.Serialization;

namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class Business
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("rating")]
        public float Rating { get; set; }
        [JsonPropertyName("review_count")]
        public int Review_Count { get; set; }
        [JsonPropertyName("price")]
        public string Price { get; set; }
        [JsonPropertyName("display_phone")]
        public string Display_Phone { get; set; }
    }
}
