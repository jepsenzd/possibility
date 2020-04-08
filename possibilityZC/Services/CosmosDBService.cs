using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using possibilityZC.Helpers;
using possibilityZC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace possibilityZC.Services
{
    public class CosmosDBService
    {
        static DocumentClient docClient = null;

        static readonly string databaseName = "Restaurants";
        static readonly string collectionName = "Restaurant";

        static async Task<bool> Initialize()
        {
            if (docClient != null)
                return true;

            try
            {
                docClient = new DocumentClient(new Uri(APIKeys.CosmosEndpointUrl), APIKeys.CosmosAuthKey);

                // Create the database - this can also be done through the portal
                await docClient.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseName });

                // Create the collection - make sure to specify the RUs - has pricing implications
                // This can also be done through the portal

                await docClient.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = collectionName },
                    new RequestOptions { OfferThroughput = 400 }
                );

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                docClient = null;

                return false;
            }

            return true;
        }

        // <GetRestaurants>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Restaurant>> GetRestaurants()
        {
            var todos = new List<Restaurant>();

            if (!await Initialize())
                return todos;

            var todoQuery = docClient.CreateDocumentQuery<Restaurant>(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .AsDocumentQuery();

            while (todoQuery.HasMoreResults)
            {
                var queryResults = await todoQuery.ExecuteNextAsync<Restaurant>();

                todos.AddRange(queryResults);
            }

            return todos;
        }
        // </GetRestaurants>


        // <GetCompletedRestaurants>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Restaurant>> GetCompletedRestaurants()
        {
            var todos = new List<Restaurant>();

            if (!await Initialize())
                return todos;

            var completedToDoQuery = docClient.CreateDocumentQuery<Restaurant>(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .AsDocumentQuery();

            while (completedToDoQuery.HasMoreResults)
            {
                var queryResults = await completedToDoQuery.ExecuteNextAsync<Restaurant>();

                todos.AddRange(queryResults);
            }

            return todos;
        }
        // </GetCompletedRestaurants>

        
    }
}
