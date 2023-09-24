using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Models
{
    internal class YesNoQuestion:Question
    {
        public bool DisqualifyCandidateIfAnswerIsNo { get; set; } = true;
    }
}
