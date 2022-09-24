namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class SearchResults
    {
        public List<Business> Businesses { get; set; }
        public SearchArguments SearchArguments { get; set; }
    }
}
