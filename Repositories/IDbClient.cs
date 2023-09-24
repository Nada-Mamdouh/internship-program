using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProgramTask.Repositories
{
    internal interface IDbClient<T>
    {
        Task Create(T document);
        Task<T> GetByTitle(string documentTitle);
        Task<List<T>> GetAll();
    }
}
