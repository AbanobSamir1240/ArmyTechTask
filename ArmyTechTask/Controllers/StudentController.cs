using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArmyTechTask.Models;

namespace ArmyTechTask.Controllers
{
    public class StudentController : Controller
    {
        private Context db = new Context();

        // GET: Student
        public async Task<ActionResult> Index()
        {
            var students = db.Students.Include(s => s.Field).Include(s => s.Governorate).Include(s => s.Neighborhood);
            return View(await students.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.FieldId = new SelectList(db.Fields, "ID", "Name");
            ViewBag.GovernorateId = new SelectList(db.Governorates, "ID", "Name");
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "ID", "Name");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,BirthDate,GovernorateId,NeighborhoodId,FieldId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FieldId = new SelectList(db.Fields, "ID", "Name", student.FieldId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "ID", "Name", student.GovernorateId);
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "ID", "Name", student.NeighborhoodId);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.FieldId = new SelectList(db.Fields, "ID", "Name", student.FieldId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "ID", "Name", student.GovernorateId);
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "ID", "Name", student.NeighborhoodId);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,BirthDate,GovernorateId,NeighborhoodId,FieldId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FieldId = new SelectList(db.Fields, "ID", "Name", student.FieldId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "ID", "Name", student.GovernorateId);
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "ID", "Name", student.NeighborhoodId);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student student = await db.Students.FindAsync(id);
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
