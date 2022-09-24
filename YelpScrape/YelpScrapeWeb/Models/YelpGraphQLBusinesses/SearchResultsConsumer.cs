namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public interface ISearchResultsConsumer
    {
        public SearchResults CreateSearchResults(SearchArguments searchArguments, List<Business> businesses);
    }
    public class SearchResultsConsumer : ISearchResultsConsumer
    {

        public SearchResults CreateSearchResults(SearchArguments searchArguments, List<Business> businesses)
        {
            SearchResults searchResultsObj = new SearchResults()
            {
                Businesses = businesses,
                SearchArguments = searchArguments
            };
            return searchResultsObj;
        }
    }
}
