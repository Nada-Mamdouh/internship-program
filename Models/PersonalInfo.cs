using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Models
{
    internal class PersonalInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        /** questions references */
        public List<string> Questions { get; set; } = new List<string>();
    }
}
