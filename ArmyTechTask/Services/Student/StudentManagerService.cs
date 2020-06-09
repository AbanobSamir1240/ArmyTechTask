using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmyTechTask.Data;
using ArmyTechTask.Repositories;
using ArmyTechTask.Repositories.Interfaces;
using ArmyTechTask.ViewModels.DisplayList;
using ArmyTechTask.ViewModels.Student;

namespace ArmyTechTask.Services.Student
{
    public class StudentManagerService : IStudentManagerService
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly IUnitOfWork _unitOfWork;

        public StudentManagerService()
        {
            _unitOfWork = new UnitOfWork(new Context());
        }


        public async Task<IEnumerable<StudentViewModel>> GetAllStudent()
        {
            return (await _unitOfWork.StudentRepository.GetAllIncludedAllData()).Select(l => new StudentViewModel()
            {
                Neighborhood = l.Neighborhood.Name,
                Name = l.Name,
                Governorate = l.Governorate.Name,
                Field = l.Field.Name,
                BirthDate = l.BirthDate,
                FieldId = l.FieldId,
                GovernorateId = l.GovernorateId,
                Id = l.ID,
                NeighborhoodId = l.NeighborhoodId
            }).ToList();
        }

        public async Task<IEnumerable<FieldViewModel>> GetAllField()
        {
            return (await _unitOfWork.FieldRepository.GetAll()).Select(l => new FieldViewModel()
            {
                Id = l.ID,
                Name = l.Name
            }).ToList();
        }

        public async Task<IEnumerable<GovernorateViewModel>> GetAllGovernorate()
        {
            return (await _unitOfWork.GovernorateRepository.GetAll()).Select(l => new GovernorateViewModel()
            {
                Id = l.ID,
                Name = l.Name
            }).ToList();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllNeighborhood()
        {
            return (await _unitOfWork.NeighborhoodRepository.GetAll()).Select(l => new NeighborhoodViewModel()
            {
                Id = l.ID,
                Name = l.Name
            }).ToList();
        }

        public async Task<string> GetGovernorate(int studentGovernorateId)
        {
            return (await _unitOfWork.GovernorateRepository.Get(studentGovernorateId))?.Name;
        }

        public async Task<string> GetField(int studentFieldId)
        {
            return (await _unitOfWork.FieldRepository.Get(studentFieldId))?.Name;
        }

        public async Task<string> GetNeighborhood(int studentNeighborhoodId)
        {
            return (await _unitOfWork.NeighborhoodRepository.Get(studentNeighborhoodId))?.Name;
        }

        public async Task Insert(StudentViewModel student)
        {
            await _unitOfWork.StudentRepository.Add(new Models.Entities.Student()
            {
                BirthDate = student.BirthDate,
                FieldId = student.FieldId,
                GovernorateId = student.GovernorateId,
                ID = 0,
                Name = student.Name,
                NeighborhoodId = student.NeighborhoodId
            });
            await _unitOfWork.CommitChanges();
        }

        public async Task<StudentViewModel> GetStudent(int id)
        {
            var student = await _unitOfWork.StudentRepository.Get(id);
            if (student == null)
            {
                return null;
            }

            return new StudentViewModel()
            {
                Name = student.Name,
                NeighborhoodId = student.NeighborhoodId,
                FieldId = student.FieldId,
                GovernorateId = student.GovernorateId,
                BirthDate = student.BirthDate,
                Id = student.ID
            };
        }

        public async Task Edit(StudentViewModel student)
        {
            var studentModel = await _unitOfWork.StudentRepository.Get(student.Id);
            studentModel.Name = student.Name;
            studentModel.BirthDate = student.BirthDate;
            studentModel.GovernorateId = student.GovernorateId;
            studentModel.FieldId = student.FieldId;
            studentModel.NeighborhoodId = student.NeighborhoodId;
            await _unitOfWork.StudentRepository.Edit(studentModel);
            await _unitOfWork.CommitChanges();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.StudentRepository.Remove(id);
            await _unitOfWork.CommitChanges();
        }
    }
}