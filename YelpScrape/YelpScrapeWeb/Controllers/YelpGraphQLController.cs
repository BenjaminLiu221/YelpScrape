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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/{controller}/{action}")]
        public async Task<IActionResult> Get()
        {
            var businesses = await _consumer.GetAllBusinesses();
            return Ok(businesses);
        }
    }
}
