using System.ComponentModel.DataAnnotations;

namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class SearchArguments
    {
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        public string? Term { get; set; }
        public string? Price { get; set; }
    }
}
