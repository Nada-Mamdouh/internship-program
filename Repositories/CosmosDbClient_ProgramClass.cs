using InternshipProgramTask.Global;
using InternshipProgramTask.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Repositories
{
    internal class CosmosDbClient_ProgramClass:IDbClient<ProgramClass>
    {
        private string containerName = "ProgramClass";
        private readonly IConfiguration _configuration;
        private string EndPointURI;
        private string PrimaryKey;
        private string ConnectionString;
        private string DatabaseName;
        private CosmosClient cosmosClient;
        private Container container;
        public CosmosDbClient_ProgramClass(IConfiguration configuration)
        {
            _configuration = configuration;
            EndPointURI = _configuration.GetSection(nameof(EndPointURI)).Value;
            PrimaryKey = _configuration.GetSection(nameof(PrimaryKey)).Value;
            ConnectionString = _configuration.GetConnectionString("cosmosCS");
            DatabaseName = _configuration.GetSection(nameof(DatabaseName)).Value;
            cosmosClient = new CosmosClient(EndPointURI, PrimaryKey);
            container = cosmosClient.GetContainer(DatabaseName, containerName);
        }


        public async Task Create(ProgramClass document)
        {
            try
            {
                var result =  container.CreateItemAsync(document);
                result.Wait();
                Console.WriteLine(result.Result.StatusCode);
                GlobalVars.CurrentProgramId = result.Result.Resource.id;
                GlobalVars.CurrentProgramTitle = result.Result.Resource.Title;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception : {ex.Message}");
            }
        }
        public async Task<ProgramClass> GetByTitle(string documentTitle)
        {
            try
            {
                QueryDefinition queryDefinition = new QueryDefinition($"SELECT * FROM c WHERE c.Title = @value")
                    .WithParameter("@value", documentTitle);

                FeedIterator<ProgramClass> queryResultSetIterator = container.GetItemQueryIterator<ProgramClass>(queryDefinition);

                while (queryResultSetIterator.HasMoreResults)
                {
                    var currentResultSet =  queryResultSetIterator.ReadNextAsync();
                    currentResultSet.Wait();
                    FeedResponse<ProgramClass> prs = currentResultSet.Result;

                    foreach (ProgramClass programClass in prs)
                    {
                        return programClass;
                    }
                }

                return null; // ProgramClass with the specified field value not found
            }
            catch (CosmosException ex)
            {
                // Handle CosmosException
                Console.WriteLine($"CosmosException: {ex.StatusCode} - {ex.Message}");
                throw;
            }
        }
        public async Task<ProgramClass> Update(string documentTitle, ProgramClass updatesObj)
        {
            ProgramClass updatedObject = GetByTitle(documentTitle).Result;
            /**Todo: 
             * => So far I can add and get and get all for Program, and add application with reference to program.
             * 1 - continue the update (to add application reference to program refrence.
             * 2 - Complete the crud for all entities.
             * 3 - Wrap up the entire application as workflow.
             * 4 - Upload file logic.
             * */
            var response = await container.UpsertItemAsync<ProgramClass>(updatedObject, new PartitionKey("/Title"));
            /*var result = await container.UpsertItemAsync(
                         updatedObject,new PartitionKey(GlobalVars.CurrentProgramId));*/
            Console.WriteLine("after update result");
            return response.Resource;
        }

        public async Task<List<ProgramClass>> GetAll()
        {
            string queryText = "SELECT * FROM c";
            QueryDefinition queryDefinition = new QueryDefinition(queryText);

            // Execute the query
            List<ProgramClass> results = new List<ProgramClass>();
            using (FeedIterator<ProgramClass> resultSetIterator = container.GetItemQueryIterator<ProgramClass>(queryDefinition))
            {
                while (resultSetIterator.HasMoreResults)
                {
                    var task =  resultSetIterator.ReadNextAsync();
                    task.Wait();
                    FeedResponse<ProgramClass> response = task.Result;
                    results.AddRange(response.Resource);
                }
            }
            Console.WriteLine("from get all");
            // Process the query results
            foreach (ProgramClass document in results)
            {
                Console.WriteLine($"ID: {document.id}, Name: {document.Title}");
            }

            // Clean up resources
            cosmosClient.Dispose();
            return results;
        }
    }
}
