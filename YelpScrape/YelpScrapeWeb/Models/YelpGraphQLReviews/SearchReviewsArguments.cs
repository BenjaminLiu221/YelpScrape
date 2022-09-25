using System.ComponentModel.DataAnnotations;

namespace YelpScrapeWeb.Models.YelpGraphQLReviews
{
    public class SearchReviewsArguments
    {
        [Required(ErrorMessage = "The business ID is required.")]
        public string Business { get; set; }
    }
}
