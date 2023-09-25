using InternshipProgramTask.Global;
using InternshipProgramTask.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Repositories
{
    internal class ProgramRepo : IProgramRepo
    {
        private IDbClient<ProgramClass> _dbClient;
        public ProgramRepo(IDbClient<ProgramClass> dbClient)
        {
            _dbClient = dbClient;
        }
        public async void Add(ProgramClass _Program)
        {
            await _dbClient.Create( _Program);
        }

        public async Task<List<ProgramClass>> GetAll()
        {
            return await _dbClient.GetAll();
        }

        public async void Update(ProgramClass _Program)
        {
            Console.WriteLine("update method is called");
            string currentProgramTitle = GlobalVars.CurrentProgramTitle;
            await _dbClient.Update(currentProgramTitle,_Program);
        }
        public async Task<ProgramClass> GetByTitle(string title)
        {

            return await _dbClient.GetByTitle(title);
        }

        
    }
}
