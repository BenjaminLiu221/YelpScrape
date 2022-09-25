using System.Text.Json.Serialization;

namespace YelpScrapeWeb.Models.YelpGraphQLReviews
{
    public class Reviews
    {
        [JsonPropertyName("review")]
        public List<Review> Review { get; set; }
    }
}
