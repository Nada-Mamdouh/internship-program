using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Models
{
    internal class Question
    {
        public string id = Guid.NewGuid().ToString();
        public enum QuestionType { };
        public string QuestionBody { get; set; }
        public string UserAnswer { get; set; }
        public bool IsInternal { get; set; } = false;
        public bool IsMandatory { get; set; } = false;
        public bool ToggleHide { get; set; } = false;
    }
}
