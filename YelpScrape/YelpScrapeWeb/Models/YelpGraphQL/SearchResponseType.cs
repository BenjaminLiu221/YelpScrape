using System.Text.Json.Serialization;

namespace YelpScrapeWeb.Models.YelpGraphQL
{
    public class SearchResponseType
    {
        [JsonPropertyName("search")]
        public Search Search { get; set; }
    }
}
