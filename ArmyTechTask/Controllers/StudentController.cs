using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using ArmyTechTask.Models.Entities;
using ArmyTechTask.Services.Student;
using ArmyTechTask.ViewModels.Student;

namespace ArmyTechTask.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentManagerService _studentManagerService;

        public StudentController()
        {
            _studentManagerService = new StudentManagerService();
        }

        public async Task<ActionResult> Index()
        {
            return View(await _studentManagerService.GetAllStudent());
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.fields = new SelectList(await _studentManagerService.GetAllField(), "Id", "Name");
            ViewBag.governorates = new SelectList(await _studentManagerService.GetAllGovernorate(), "Id", "Name");
            ViewBag.neighborhoods = new SelectList(await _studentManagerService.GetAllNeighborhood(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                student.Governorate = await _studentManagerService.GetGovernorate(student.GovernorateId);
                student.Field = await _studentManagerService.GetField(student.FieldId);
                student.Neighborhood = await _studentManagerService.GetNeighborhood(student.NeighborhoodId);
                return View("SaveStudent", student);
            }

            ViewBag.fields = new SelectList(await _studentManagerService.GetAllField(), "Id", "Name");
            ViewBag.governorates = new SelectList(await _studentManagerService.GetAllGovernorate(), "Id", "Name");
            ViewBag.neighborhoods = new SelectList(await _studentManagerService.GetAllNeighborhood(), "Id", "Name");
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                await _studentManagerService.Insert(student);
                return RedirectToAction("Index");
            }

            return View("Create", student);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var student = await _studentManagerService.GetStudent((int) id);
            if (student == null)
            {
                return RedirectToAction("Create");
            }

            ViewBag.fields = new SelectList(await _studentManagerService.GetAllField(), "Id", "Name");
            ViewBag.governorates = new SelectList(await _studentManagerService.GetAllGovernorate(), "Id", "Name");
            ViewBag.neighborhoods = new SelectList(await _studentManagerService.GetAllNeighborhood(), "Id", "Name");
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                await _studentManagerService.Edit(student);
                return RedirectToAction("Index");
            }

            ViewBag.fields = new SelectList(await _studentManagerService.GetAllField(), "Id", "Name");
            ViewBag.governorates = new SelectList(await _studentManagerService.GetAllGovernorate(), "Id", "Name");
            ViewBag.neighborhoods = new SelectList(await _studentManagerService.GetAllNeighborhood(), "Id", "Name");
            return View(student);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Index");
            }

            await _studentManagerService.Delete((int) id);
            return RedirectToAction("Index");
        }

    }
}
