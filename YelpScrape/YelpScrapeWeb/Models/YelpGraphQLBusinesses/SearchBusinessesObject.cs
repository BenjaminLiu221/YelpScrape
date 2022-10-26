namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public class SearchBusinessesObject
    {
        public List<Business> Businesses { get; set; }
        public int Total { get; set; }
    }
}
