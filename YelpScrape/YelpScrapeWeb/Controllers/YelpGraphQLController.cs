using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using YelpScrapeWeb.Data;
using YelpScrapeWeb.Models.YelpGraphQL;

namespace YelpScrapeWeb.Controllers
{
    public class YelpGraphQLController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public YelpGraphQLController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authorizationToken = _dbContext.Authorizations.FirstOrDefault().Token;
            var _client = new GraphQLHttpClient("https://api.yelp.com/v3/graphql", new NewtonsoftJsonSerializer());
            _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorizationToken);
            var query = new GraphQLRequest
            {
                Query = @"
                query($termId: String $locationId: String){
                    search(term:$termId location:$locationId) {
                        business {
                            name
                        }
                    }
                }",
                Variables = new
                {
                    termId = "burrito",
                    locationId = "san francisco"
                }
            };
            var response = await _client.SendQueryAsync<SearchResponseType>(query);
            var businesses = response.Data;
            return Ok(businesses);
        }
    }
}
