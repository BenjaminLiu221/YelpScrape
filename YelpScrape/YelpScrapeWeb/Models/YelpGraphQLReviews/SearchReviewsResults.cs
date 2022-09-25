namespace YelpScrapeWeb.Models.YelpGraphQLReviews
{
    public class SearchReviewsResults
    {
        public List<Review> Reviews { get; set; }
        public SearchReviewsArguments SearchReviewsArguments { get; set; }
    }
}
