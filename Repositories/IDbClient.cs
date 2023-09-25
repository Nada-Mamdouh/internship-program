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
        Task<T> Update(string documentTitle, T document);
        Task<List<T>> GetAll();
    }
}
