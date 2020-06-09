using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ArmyTechTask.Repositories.Student
{
    public class StudentRepository : Repository<Models.Entities.Student>,
        IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Models.Entities.Student>> GetAllIncludedAllData()
        {
            return await entities.Include(l => l.Governorate).Include(l => l.Neighborhood).Include(l => l.Field)
                .ToListAsync();
        }

        public async Task<Models.Entities.Student> GetIncludedAllData(int? id)
        {
            return await entities.Include(l => l.Governorate).Include(l => l.Neighborhood).Include(l => l.Field)
                .FirstOrDefaultAsync(l => l.ID == id);
        }
    }
}