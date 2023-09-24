using InternshipProgramTask.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Models
{
    internal class Workflow
    {
        public string Id = Guid.NewGuid().ToString();
        public string ProgramId { get; set; }
        public string ApplicationId { get; set; }
        public List<Stage> Stages { get; set; } 
        public string CurrentStageId { get; set; }
    }
}
