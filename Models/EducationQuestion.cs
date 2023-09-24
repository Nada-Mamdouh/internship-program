using InternshipProgramTask.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Models
{
    internal class EducationQuestion : Question
    {
        public string School { get; set; }
        public EducationlDegree Degree { get; set; }
        public string CourseName { get; set; }
        public List<string> LocationOfStudy { get; set; } = new List<string>() { "UK", "Egypt", "USA" };
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyStudyHere { get; set; } = false;
    }
}
