using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net.Http.Headers;
using YelpScrapeWeb.Data;

namespace YelpScrapeWeb.Models.YelpGraphQL
{
    public interface ISearchConsumer
    {
        public Task<List<Business>> GetAllBusinesses(SearchLocation searchLocation);
    }
    public class SearchConsumer : ISearchConsumer
    {
        private readonly ApplicationDbContext _dbContext;

        public SearchConsumer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Business>> GetAllBusinesses(SearchLocation searchLocation)
        {
            var authorization = _dbContext.Authorizations.FirstOrDefault().Token;
            var _client = new GraphQLHttpClient("https://api.yelp.com/v3/graphql", new NewtonsoftJsonSerializer());
            _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
            string location = "";
            if (searchLocation != null)
            {
                location = searchLocation.Location;
            }
            var query = new GraphQLRequest
            {
                Query = @"
                query($termId: String $locationId: String){
                    search(term:$termId location:$locationId) {
                        business {
                            id
                            name
                        }
                    }
                }",
                Variables = new
                {
                    termId = "burrito",
                    locationId = location
                }
            };
            var response = await _client.SendQueryAsync<SearchResponseType>(query);
            var businesses = response.Data.Search.business;
            return businesses;
        }
    }
}
