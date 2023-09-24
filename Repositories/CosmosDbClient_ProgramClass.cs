using InternshipProgramTask.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
                ItemResponse<ProgramClass> response = await container.CreateItemAsync(document);
                Console.WriteLine(response.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception : {ex.Message}");
            }
        }
        /*Task async GetAll()
        {

        }*/
        public async Task<ProgramClass> GetByTitle(string documentTitle)
        {
            string partitionKey = "/Title";

            ItemResponse<ProgramClass> response = await container.ReadItemAsync<ProgramClass>(documentTitle, new PartitionKey(partitionKey));
            ProgramClass document = response?.Resource;
            return response;
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
