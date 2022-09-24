namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class SearchResults
    {
        public List<Business> Businesses { get; set; }
        public SearchLocation SearchLocation { get; set; }
    }
}
