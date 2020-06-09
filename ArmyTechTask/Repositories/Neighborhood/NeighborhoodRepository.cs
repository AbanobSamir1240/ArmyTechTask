using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ArmyTechTask.Repositories.Neighborhood
{
    public class NeighborhoodRepository : Repository<Models.Entities.Neighborhood>,
        INeighborhoodRepository
    {
        public NeighborhoodRepository(DbContext context) : base(context)
        {
        }
        
    }
}