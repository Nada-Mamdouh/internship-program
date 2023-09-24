using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Models
{
    internal class WorkExperienceQuestion : Question
    {
        public string Company { get; set; }
        public string Title { get; set; }
        public List<string> Location = new List<string>() { "UK", "Egypt", "USA" };
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyWorkThere { get; set; } = false;
    }
}
