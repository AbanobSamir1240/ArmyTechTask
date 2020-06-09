using System.Collections.Generic;
using System.Threading.Tasks;
using ArmyTechTask.ViewModels.DisplayList;
using ArmyTechTask.ViewModels.Student;

namespace ArmyTechTask.Services.Student
{
    public interface IStudentManagerService
    {
        Task<IEnumerable<StudentViewModel>> GetAllStudent();
        Task<IEnumerable<FieldViewModel>> GetAllField();
        Task<IEnumerable<GovernorateViewModel>> GetAllGovernorate();
        Task<IEnumerable<NeighborhoodViewModel>> GetAllNeighborhood();

        Task<string> GetGovernorate(int studentGovernorateId);
        Task<string> GetField(int studentFieldId);
        Task<string> GetNeighborhood(int studentNeighborhoodId);
        Task Insert(StudentViewModel student);
        Task<StudentViewModel> GetStudent(int id);
        Task Edit(StudentViewModel student);
        Task Delete(int id);
    }
}