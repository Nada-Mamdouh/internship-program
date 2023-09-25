using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipProgramTask.Repositories;
using Microsoft.Extensions.Configuration;
using InternshipProgramTask.Global;
using InternshipProgramTask.DataTypes;

namespace InternshipProgramTask.Models
{
    internal class App
    {
        private readonly IConfiguration _configuration;
        private readonly IProgramRepo _programRepo;
        private readonly IDbClient<Application> _appClient;

        public App(IConfiguration configuration, IProgramRepo programRepo, IDbClient<Application> appClient)
        {
            _configuration = configuration;
            _programRepo = programRepo;
            _appClient = appClient;
        }


        public async void Run(string[] args)
        {
            ProgramClass pc = new ProgramClass();
            pc.id = Guid.NewGuid().ToString();
            pc.Title = "Internship Program 4";
            pc.Summary = "This internship Program 4 summary";
            pc.Discription = "This is Internship Program 4 description";
            List<string> skills = new List<string>() { "OOP", "Problem Solving", "Programming" };
            pc.KeySkills.AddRange(skills);
            pc.Benefits = "Internship Program 4 benefits";
            pc.Criteria = "Internship Program 4 criteria";
            pc.ProgramType.Add("Program type 4");
            pc.Start = new DateTime(2023-09-30);
            pc.ApplicationOpen = new DateTime(2023 , 10 , 10);
            pc.ApplicationClose = new DateTime(2023 , 10 , 20);
            pc.Duration = "6 Months";
            pc.ProgramLocation = "London, UK";
            pc.MinQualifications.Add("Work Visa");
            pc.MaxNoOfApplications = "5";

            /*var shortlisting = new Stage();
            shortlisting.Name =nameof(StagePhase.Shortlisting);
            shortlisting.Description = "shortlisting description";
            shortlisting.Questions = new List<string>();

            var videointerview = new Stage();
            videointerview.Name = nameof(StagePhase.VideoInterview);
            videointerview.Description = "video interview description";
            videointerview.Questions = new List<string>();

            var placement = new Stage();
            placement.Name = nameof(StagePhase.Placement);
            placement.Description = "placement description";
            placement.Questions = new List<string>();*/

            Console.WriteLine(pc.id);
            
            //_programRepo.Add(pc);
            Console.WriteLine("================================the globals================");
            GlobalVars.CurrentProgramId = "c1643cf9-851f-4923-8c2b-0b2b26d27a0f";
            GlobalVars.CurrentProgramTitle = "Internship Program 3";
            Console.WriteLine(GlobalVars.CurrentProgramId);
            Console.WriteLine(GlobalVars.CurrentProgramTitle);
            Console.WriteLine("end of globals===========================");
            var res = await _programRepo.GetByTitle(pc.Title);
            Application internApplication = new Application();
            internApplication.ProgramId = GlobalVars.CurrentProgramId;
            internApplication.CoverImage = "test coverimage";
            await _appClient.Create(internApplication);
            Console.WriteLine(res.Title);
            _programRepo.GetAll();
        }
    }
}
