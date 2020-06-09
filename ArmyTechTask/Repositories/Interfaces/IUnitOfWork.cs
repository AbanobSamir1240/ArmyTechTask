using System;
using System.Threading.Tasks;
using ArmyTechTask.Repositories.Field;
using ArmyTechTask.Repositories.Governorate;
using ArmyTechTask.Repositories.Neighborhood;
using ArmyTechTask.Repositories.Student;

namespace ArmyTechTask.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        IFieldRepository FieldRepository { get; }
        INeighborhoodRepository NeighborhoodRepository { get; }
        IGovernorateRepository GovernorateRepository { get; }
        Task<int> CommitChanges();
    }
}
