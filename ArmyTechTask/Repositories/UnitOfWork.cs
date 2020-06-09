using System.Data.Entity;
using System.Threading.Tasks;
using ArmyTechTask.Repositories.Field;
using ArmyTechTask.Repositories.Governorate;
using ArmyTechTask.Repositories.Interfaces;
using ArmyTechTask.Repositories.Neighborhood;
using ArmyTechTask.Repositories.Student;

namespace ArmyTechTask.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            StudentRepository = new StudentRepository(_context);
            FieldRepository = new FieldRepository(_context);
            NeighborhoodRepository = new NeighborhoodRepository(_context);
            GovernorateRepository = new GovernorateRepository(_context);
        }


        public IStudentRepository StudentRepository { get; private set; }
        public IFieldRepository FieldRepository { get; private set; }
        public INeighborhoodRepository NeighborhoodRepository { get; private set; }
        public IGovernorateRepository GovernorateRepository { get; private set; }

        public async Task<int> CommitChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}