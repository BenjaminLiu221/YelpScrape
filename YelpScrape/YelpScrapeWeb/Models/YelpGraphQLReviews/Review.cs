using System.Text.Json.Serialization;

namespace YelpScrapeWeb.Models.YelpGraphQLReviews
{
    public class Review
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("user")]
        public User User { get; set; }
        [JsonPropertyName("rating")]
        public double Rating { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("time_created")]
        public string Time_Created { get; set; }
    }
}
