using System.Text.Json.Serialization;

namespace YelpScrapeWeb.Models.YelpGraphQLReviews
{
    public class ReviewsResponseType
    {
        [JsonPropertyName("reviews")]
        public Reviews Reviews { get; set; }
    }
}
