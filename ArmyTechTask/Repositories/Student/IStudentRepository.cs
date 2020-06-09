using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArmyTechTask.Repositories.Student
{
    public interface IStudentRepository : Interfaces.IRepository<Models.Entities.Student>
    {
        Task<IEnumerable<Models.Entities.Student>> GetAllIncludedAllData();
        Task<Models.Entities.Student> GetIncludedAllData(int? id);
    }
}
