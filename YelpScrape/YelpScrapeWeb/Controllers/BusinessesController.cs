using Microsoft.AspNetCore.Mvc;
using YelpScrapeWeb.Models.YelpGraphQL;

namespace YelpScrapeWeb.Controllers
{
    public class BusinessesController : Controller
    {
        private readonly ISearchConsumer _consumer;

        public BusinessesController(ISearchConsumer consumer)
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
            if (!this.ModelState.IsValid)
            {
                return View();
            }
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
