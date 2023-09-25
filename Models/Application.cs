using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Models
{
    internal class Application
    {
        public string id = Guid.NewGuid().ToString();
        public string CoverImage { get; set; }
        public PersonalInfo PersonalInfoSec { get; set; }
		public List<string> ProfileSec { get; set; } = new List<string>();
		public List<string> AdditionalQuestionsSec { get; set; } = new List<string>();
        public string ProgramId { get; set; }
    }
}
