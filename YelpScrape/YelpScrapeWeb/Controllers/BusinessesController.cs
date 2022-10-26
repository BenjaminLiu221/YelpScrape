using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Web;
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

            return RedirectToAction("GetBusinesses", searchBusinessesArguments);
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinesses(SearchBusinessesArguments searchBusinessesArguments, int offset)
        {
            var searchBusinessesObj = await _searchBusinessesConsumer.GetAllBusinesses(searchBusinessesArguments, offset);
            var businesses = searchBusinessesObj.Businesses;
            var total = searchBusinessesObj.Total;
            var searchResultsObj = _searchBusinessesResultsConsumer.CreateSearchResults(searchBusinessesArguments, businesses, total);

            return View(searchResultsObj);
        }
    }
}
