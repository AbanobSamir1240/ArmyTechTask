using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ArmyTechTask.Repositories.Field
{
    public class FieldRepository : Repository<Models.Entities.Field>,
        IFieldRepository
    {
        public FieldRepository(DbContext context) : base(context)
        {
        }
    }
}