using Microsoft.AspNetCore.Mvc;
using YelpScrapeWeb.Models.YelpGraphQL;

namespace YelpScrapeWeb.Controllers
{
    public class YelpGraphQLController : Controller
    {
        private readonly ISearchConsumer _consumer;

        public YelpGraphQLController(ISearchConsumer consumer)
        {
            _consumer = consumer;
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        // SearchBusiness
        public async Task<IActionResult> Search(SearchLocation searchLocation)
        {
            var businesses = await _consumer.GetAllBusinesses(searchLocation);
            SearchResults searchResults = new SearchResults()
            {
                Businesses = businesses,
                SearchLocation = searchLocation
            };
            //return Ok(businesses);
            return View(searchResults);
        }
    }
}
