namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public interface ISearchBusinessesResultsConsumer
    {
        public SearchBusinessesResults CreateSearchResults(SearchBusinessesArguments searchBusinessesArguments, List<Business> businesses, int total);
    }
    public class SearchBusinessesResultsConsumer : ISearchBusinessesResultsConsumer
    {

        public SearchBusinessesResults CreateSearchResults(SearchBusinessesArguments searchBusinessesArguments, List<Business> businesses, int total)
        {
            SearchBusinessesResults searchBusinessesResultsObj = new SearchBusinessesResults()
            {
                Businesses = businesses,
                SearchBusinessesArguments = searchBusinessesArguments,
                Paging = PageOffSet(CalculatePage(total))
            };
            return searchBusinessesResultsObj;
        }

        private int CalculatePage(int totalBusinesses)
        {
            int maxPages = 0;

            if (totalBusinesses % 10 > 0)
            {
                maxPages = totalBusinesses / 10 + 1;
            }
            else
            {
                maxPages = totalBusinesses / 10;
            }

            return maxPages;
        }

        private Dictionary<int, int> PageOffSet(int maxPages)
        {
            Dictionary<int, int> pageOffSet = new Dictionary<int, int>();

            for (int i = 0; i < maxPages; i++)
            {
                // key page, value offset
                pageOffSet.Add(i + 1, i * 10);
            }

            return pageOffSet;
        }
    }
}
