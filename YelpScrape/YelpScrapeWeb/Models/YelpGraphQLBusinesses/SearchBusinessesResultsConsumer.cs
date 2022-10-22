namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public interface ISearchBusinessesResultsConsumer
    {
        public SearchBusinessesResults CreateSearchResults(SearchBusinessesArguments searchBusinessesArguments, List<Business> businesses);
    }
    public class SearchBusinessesResultsConsumer : ISearchBusinessesResultsConsumer
    {

        public SearchBusinessesResults CreateSearchResults(SearchBusinessesArguments searchBusinessesArguments, List<Business> businesses)
        {
            SearchBusinessesResults searchBusinessesResultsObj = new SearchBusinessesResults()
            {
                Businesses = businesses,
                SearchBusinessesArguments = searchBusinessesArguments,
            };
            return searchBusinessesResultsObj;
        }
    }
}
