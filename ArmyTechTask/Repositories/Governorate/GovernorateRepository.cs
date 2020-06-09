using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ArmyTechTask.Repositories.Governorate
{
    public class GovernorateRepository : Repository<Models.Entities.Governorate>,
        IGovernorateRepository
    {
        public GovernorateRepository(DbContext context) : base(context)
        {
        }


    }
}
