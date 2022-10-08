﻿using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net.Http.Headers;
using YelpScrapeWeb.Data;

namespace YelpScrapeWeb.Models.YelpGraphQLBusinesses
{
    public interface ISearchBusinessesConsumer
    {
        public Task<List<Business>> GetAllBusinesses(SearchBusinessesArguments searchBusinessesArguments);
    }
    public class SearchBusinessesConsumer : ISearchBusinessesConsumer
    {
        private readonly ApplicationDbContext _dbContext;

        public SearchBusinessesConsumer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Business>> GetAllBusinesses(SearchBusinessesArguments searchBusinessesArguments)
        {
            var authorization = _dbContext.Authorizations.FirstOrDefault().Token;
            var _client = new GraphQLHttpClient("https://api.yelp.com/v3/graphql", new NewtonsoftJsonSerializer());
            _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

            string location = "";
            string term = "";
            string price = "";

            if (searchBusinessesArguments.Location != null)
            {
                location = searchBusinessesArguments.Location;
            }

            if (searchBusinessesArguments.Term != null)
            {
                term = searchBusinessesArguments.Term;
            }

            if (searchBusinessesArguments.Price != null)
            {
                price = searchBusinessesArguments.Price.ToString();
            }

            var query = new GraphQLRequest
            {
                Query = @"
                query($termId: String $locationId: String){
                    search(term:$termId location:$locationId) {
                        business {
                            id
                            name
                            rating
                            review_count
                            price
                            display_phone
                        }
                    }
                }",
                Variables = new
                {
                    termId = term,
                    locationId = location,
                    price = price
                }
            };
            // Test if response is http request timeout here.

            var testResponse = Task.Run(async () => await _client.SendQueryAsync<SearchResponseType>(query)).Result;
            var response = await _client.SendQueryAsync<SearchResponseType>(query);
            //If broken, StatusCode500 most likely. search query breaks. reviews that I've seen
            var businesses = response.Data.Search.business;
            return businesses;
        }
    }
}
