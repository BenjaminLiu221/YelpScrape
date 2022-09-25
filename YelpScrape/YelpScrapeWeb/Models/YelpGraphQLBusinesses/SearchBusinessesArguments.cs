using System.ComponentModel.DataAnnotations;

namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class SearchBusinessesArguments
    {
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        public string? Term { get; set; }
        [Range(1,4)]
        public int? Price { get; set; }
    }
}
