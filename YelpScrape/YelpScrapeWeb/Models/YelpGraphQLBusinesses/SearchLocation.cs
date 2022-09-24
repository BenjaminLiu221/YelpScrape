using System.ComponentModel.DataAnnotations;

namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class SearchLocation
    {
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
    }
}
