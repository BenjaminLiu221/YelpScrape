namespace YelpScrapeWeb.Models.YelpGraphQLReviews
{
    public interface ISearchReviewsResultsConsumer
    {
        public SearchReviewsResults CreateSearchResults(SearchReviewsArguments searchReviewsArguments, List<Review> reviews);
    }
    public class SearchReviewsResultsConsumer : ISearchReviewsResultsConsumer
    {
        public SearchReviewsResults CreateSearchResults(SearchReviewsArguments searchReviewsArguments, List<Review> reviews)
        {
            SearchReviewsResults searchReviewsResultsObj = new SearchReviewsResults()
            {
                Reviews = reviews,
                SearchReviewsArguments = searchReviewsArguments
            };
            return searchReviewsResultsObj;
        }
    }
}
