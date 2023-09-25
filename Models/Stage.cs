using InternshipProgramTask.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Models
{
    internal class Stage
    {
        public string id = Guid.NewGuid().ToString();
        public string Name { get; set; }// = StagePhase.Shortlisting.ToString();
        public string Description { get; set; }
        public List<string> Questions = new List<string>();
    }
}
