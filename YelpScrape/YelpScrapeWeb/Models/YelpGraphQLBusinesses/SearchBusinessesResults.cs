namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class SearchBusinessesResults
    {
        public List<Business> Businesses { get; set; }
        public SearchBusinessesArguments SearchBusinessesArguments { get; set; }
    }
}
