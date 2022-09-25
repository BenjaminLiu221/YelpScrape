using Microsoft.AspNetCore.Mvc;
using YelpScrapeWeb.Models.YelpGraphQLBusinesses;

namespace YelpScrapeWeb.Controllers
{
    public class BusinessesController : Controller
    {
        private readonly ISearchBusinessesConsumer _searchBusinessesConsumer;
        private readonly ISearchBusinessesResultsConsumer _searchBusinessesResultsConsumer;

        public BusinessesController(ISearchBusinessesConsumer searchBusinessesConsumer, ISearchBusinessesResultsConsumer searchBusinessesResultsConsumer)
        {
            _searchBusinessesConsumer = searchBusinessesConsumer;
            _searchBusinessesResultsConsumer = searchBusinessesResultsConsumer;
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        // SearchBusiness
        public async Task<IActionResult> Search(SearchBusinessesArguments searchBusinessesArguments)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            var businesses = await _searchBusinessesConsumer.GetAllBusinesses(searchBusinessesArguments);
            var searchResultsObj = _searchBusinessesResultsConsumer.CreateSearchResults(searchBusinessesArguments, businesses);

            return View(searchResultsObj);
        }
    }
}
