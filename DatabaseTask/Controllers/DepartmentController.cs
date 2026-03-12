using DatabaseTask.EF;
using DatabaseTask.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.Controllers
{
    public class DepartmentController : Controller
    {
        StudentMsBsp26Context db;
        public DepartmentController(StudentMsBsp26Context db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.Departments.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department d)
        {
            db.Departments.Add(d);
            db.SaveChanges();

            TempData["Msg"] = d.Name + " created successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var data = (from d in db.Departments where d.Id == id select d).SingleOrDefault();
            return View(data);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var dept = db.Departments.Find(id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Update(Department d)
        {
            db.Departments.Update(d);
            db.SaveChanges();

            TempData["Msg"] = d.Name + " updated successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var del = db.Departments.Find(id);
            db.Departments.Remove(del);
            db.SaveChanges();

            TempData["Msg"] = id + " deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
