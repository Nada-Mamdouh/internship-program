using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipProgramTask.Repositories;
using Microsoft.Extensions.Configuration;

namespace InternshipProgramTask.Models
{
    internal class App
    {
        private readonly IConfiguration _configuration;
        private readonly IProgramRepo _programRepo;

        public App(IConfiguration configuration, IProgramRepo programRepo)
        {
            _configuration = configuration;
            _programRepo = programRepo;
        }
        public void DoWork()
        {
            var keyValuePairs = _configuration.AsEnumerable().ToList();
            string EndPointURI = _configuration.GetSection(nameof(EndPointURI)).Value;
            string PrimaryKey = _configuration.GetSection(nameof(PrimaryKey)).Value;
            string ConnectionString = _configuration.GetConnectionString("cosmosCS");
            string DatabaseName = _configuration.GetSection(nameof(DatabaseName)).Value;
            Console.WriteLine("==============================================");
            Console.WriteLine("Configurations...");
            Console.WriteLine("==============================================");
            Console.WriteLine("connection string => "+ConnectionString);
            Console.WriteLine("end point uri =>>"+EndPointURI);
            Console.WriteLine("pk =>"+PrimaryKey);
            Console.WriteLine("dbname " + DatabaseName);
            Console.WriteLine("==============================================");
        }

        public async void Run(string[] args)
        {
            ProgramClass pc = new ProgramClass();
            pc.id = Guid.NewGuid().ToString();
            pc.Title = "Internship Program 1";
            pc.Summary = "This internship Program 2 summary";
            pc.Discription = "This is Internship Program 2 description";
            List<string> skills = new List<string>() { "OOP", "Problem Solving", "Programming" };
            pc.KeySkills.AddRange(skills);
            pc.Benefits = "Internship Program 2 benefits";
            pc.Criteria = "Internship Program 2 criteria";
            pc.ProgramType.Add("Program type 2");
            pc.Start = new DateTime(2023-09-30);
            pc.ApplicationOpen = new DateTime(2023 , 09 , 10);
            pc.ApplicationClose = new DateTime(2023 , 09 , 20);
            pc.Duration = "6 Months";
            pc.ProgramLocation = "London, UK";
            pc.MinQualifications.Add("Work Visa");
            pc.MaxNoOfApplications = "5";
            Console.WriteLine(pc.id);
            //_programRepo.Add(pc);
            Console.WriteLine(_programRepo.GetByTitle(pc.Title).ToString());
            _programRepo.GetAll();
        }
    }
}
