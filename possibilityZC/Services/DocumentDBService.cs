using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using possibilityZC.Helpers;
using possibilityZC.Models;

namespace possibilityZC.Services
{
    public class DocumentDBService
    {
        static DocumentClient docClient = null;

        static readonly string databaseName = "Recipes";
        static readonly string collectionName = "Recipe";

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

        public async static Task<List<Recipe>> GetRecipeItems()
        {
            var recipes = new List<Recipe>();

            if (!await Initialize())
                return recipes;

            var recipeQuery = docClient.CreateDocumentQuery<Recipe>(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(recipe => recipe.Saved == false)
                .AsDocumentQuery();

            while (recipeQuery.HasMoreResults)
            {
                var queryResults = await recipeQuery.ExecuteNextAsync<Recipe>();

                recipes.AddRange(queryResults);
            }

            return recipes;
        }
        
        public async static Task<List<Recipe>> GetSavedRecipeItems()
        {
            var recipes = new List<Recipe>();

            if (!await Initialize())
                return recipes;

            var completedRecipeQuery = docClient.CreateDocumentQuery<Recipe>(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(recipe => recipe.Saved == true)
                .AsDocumentQuery();

            while (completedRecipeQuery.HasMoreResults)
            {
                var queryResults = await completedRecipeQuery.ExecuteNextAsync<Recipe>();

                recipes.AddRange(queryResults);
            }

            return recipes;
        }
        
        public async static Task SaveRecipeItem(Recipe item)
        {
            item.Saved = true;

            await UpdateRecipeItem(item);
        }
        
        public async static Task InsertRecipeItem(Recipe item)
        {
            if (!await Initialize())
                return;

            await docClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                item);
        }
       
        public async static Task DeleteRecipeItem(Recipe item)
        {
            if (!await Initialize())
                return;

            var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, item.Id);
            await docClient.DeleteDocumentAsync(docUri);
        }
        
        public async static Task UpdateRecipeItem(Recipe item)
        {
            if (!await Initialize())
                return;

            var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, item.Id);
            await docClient.ReplaceDocumentAsync(docUri, item);
        }
         
    }
}
