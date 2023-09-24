using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Models
{
    internal class MultiChoice:Question
    {
        public List<string> Choices = new List<string>();

        public List<string> SelectedChoices = new List<string>();
        public bool IsOtherChoiceEnabled { get; set; } = false;
        public string MaxChoicesAllowed { get; set; }

    }
}
