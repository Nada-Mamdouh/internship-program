using InternshipProgramTask.Global;
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
    internal class ApplicationRepo:IDbClient<Application>
    {
        private string containerName = "Application";
        private readonly IConfiguration _configuration;
        private string EndPointURI;
        private string PrimaryKey;
        private string ConnectionString;
        private string DatabaseName;
        private CosmosClient cosmosClient;
        private Container container;
        private IProgramRepo programRepo;
        public ApplicationRepo(IConfiguration configuration, IProgramRepo pr)
        {
            _configuration = configuration;
            EndPointURI = _configuration.GetSection(nameof(EndPointURI)).Value;
            PrimaryKey = _configuration.GetSection(nameof(PrimaryKey)).Value;
            ConnectionString = _configuration.GetConnectionString("cosmosCS");
            DatabaseName = _configuration.GetSection(nameof(DatabaseName)).Value;
            cosmosClient = new CosmosClient(EndPointURI, PrimaryKey);
            container = cosmosClient.GetContainer(DatabaseName, containerName);
            programRepo = pr;
        }
        public async Task Create(Application document)
        {
            try
            {
                var result = container.CreateItemAsync(document);
                result.Wait();
                Console.WriteLine(result.Result.StatusCode);
                var appId = result.Result.Resource.id;
                ProgramClass currentProgram = programRepo.GetByTitle(GlobalVars.CurrentProgramTitle).Result;
                currentProgram.ApplicationIds.Add(appId);
                programRepo.Update(currentProgram);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception : {ex.Message}");
            }
        }
        public async Task<Application> Update(string documentTitle, Application updatesObj)
        {
            throw new NotImplementedException();
        }
        public Task<Application> GetByTitle(string documentTitle)
        {
            throw new NotImplementedException();
        }
        public Task<List<Application>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
