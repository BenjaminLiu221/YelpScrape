using Microsoft.AspNetCore.Mvc;
using YelpScrapeWeb.Models.YelpGraphQLReviews;

namespace YelpScrapeWeb.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ISearchReviewsConsumer _searchReviewsConsumer;
        private readonly ISearchReviewsResultsConsumer _searchReviewsResultsConsumer;

        public ReviewsController(ISearchReviewsConsumer searchReviewsConsumer, ISearchReviewsResultsConsumer searchReviewsResultsConsumer)
        {
            _searchReviewsConsumer = searchReviewsConsumer;
            _searchReviewsResultsConsumer = searchReviewsResultsConsumer;
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        // SearchReviews
        public async Task<IActionResult> Search(SearchReviewsArguments searchReviewsArguments)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            var reviews = await _searchReviewsConsumer.GetAllReviews(searchReviewsArguments);
            var searchResultsObj = _searchReviewsResultsConsumer.CreateSearchResults(searchReviewsArguments, reviews);

            return View(searchResultsObj);
        }
    }
}
