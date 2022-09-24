namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public interface ISearchResultsConsumer
    {
        public SearchResults CreateSearchResults(SearchLocation searchLocation, List<Business> businesses);
    }
    public class SearchResultsConsumer : ISearchResultsConsumer
    {

        public SearchResults CreateSearchResults(SearchLocation searchLocation, List<Business> businesses)
        {
            SearchResults searchResultsObj = new SearchResults()
            {
                Businesses = businesses,
                SearchLocation = searchLocation
            };
            return searchResultsObj;
        }
    }
}
