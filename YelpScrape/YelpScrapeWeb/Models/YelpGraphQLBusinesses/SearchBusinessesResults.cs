namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class SearchBusinessesResults
    {
        public List<Business> Businesses { get; set; }
        public SearchBusinessesArguments SearchBusinessesArguments { get; set; }
        public Dictionary<int, int> Paging = new Dictionary<int, int> { { 1, 0 }, { 2, 10 }, { 3, 20}, { 4, 30} };
    }
}
