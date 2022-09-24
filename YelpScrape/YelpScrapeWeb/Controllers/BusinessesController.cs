using Microsoft.AspNetCore.Mvc;
using YelpScrapeWeb.Models.YelpGraphQLBusinesses;

namespace YelpScrapeWeb.Controllers
{
    public class BusinessesController : Controller
    {
        private readonly ISearchConsumer _searchConsumer;
        private readonly ISearchResultsConsumer _searchResultsConsumer;

        public BusinessesController(ISearchConsumer searchConsumer, ISearchResultsConsumer searchResultsConsumer)
        {
            _searchConsumer = searchConsumer;
            _searchResultsConsumer = searchResultsConsumer;
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

            var businesses = await _searchConsumer.GetAllBusinesses(searchLocation);
            var searchResultsObj = _searchResultsConsumer.CreateSearchResults(searchLocation, businesses);

            return View(searchResultsObj);
        }
    }
}
