using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Models
{
    internal class ProgramClass
    {
        public string id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Discription { get; set; }
        public List<string> KeySkills { get; set; } = new List<string>();
        public string Benefits { get; set; }
        public string Criteria { get; set; }
        public List<string> ProgramType { get; set; } = new List<string>();
        public DateTime Start { get; set; }
        public DateTime ApplicationOpen { get; set; }
        public DateTime ApplicationClose { get; set; }
        public string Duration { get; set; }
        public string ProgramLocation { get; set; }
        public List<string> MinQualifications { get; set; } = new List<string>();
        public string MaxNoOfApplications { get; set; }
        public List<string> ApplicationIds { get; set; } = new List<string>();
        public List<string> Stages { get; set; } = new List<string>();
        public Stage CurrentStage { get; set; }
    }
}
