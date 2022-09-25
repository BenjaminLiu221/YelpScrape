using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net.Http.Headers;
using YelpScrapeWeb.Data;

namespace YelpScrapeWeb.Models.YelpGraphQLReviews
{
    public interface ISearchReviewsConsumer
    {
        public Task<List<Review>> GetAllReviews(SearchReviewsArguments searchReviewsArguments);
    }
    public class SearchReviewsConsumer : ISearchReviewsConsumer
    {
        private readonly ApplicationDbContext _dbContext;

        public SearchReviewsConsumer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Review>> GetAllReviews(SearchReviewsArguments searchReviewsArguments)
        {
            var authorization = _dbContext.Authorizations.FirstOrDefault().Token;
            var _client = new GraphQLHttpClient("https://api.yelp.com/v3/graphql", new NewtonsoftJsonSerializer());
            _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

            string business = "";

            if (searchReviewsArguments.Business != null)
            {
                business = searchReviewsArguments.Business;
            }

            var query = new GraphQLRequest
            {
                Query = @"
                query($businessId: String){
                    reviews(business:$businessId) {
                        review {
                            id
                            rating
                            user {
                                id
                            }
                            text
                            time_created
                        }
                    }
                }",
                Variables = new
                {
                    businessId = business,
                }
            };
            var response = await _client.SendQueryAsync<ReviewsResponseType>(query);
            var reviews = response.Data.Reviews.Review;
            return reviews;
        }
    }
}
