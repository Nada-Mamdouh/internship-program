using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipProgramTask.Models;

namespace InternshipProgramTask.Repositories
{
    internal interface IProgramRepo
    {
        Task<List<ProgramClass>> GetAll();
        Task<ProgramClass> GetByTitle(string title);
        void Add(ProgramClass _Program);
        void Update(ProgramClass _Program); 

    }
}
