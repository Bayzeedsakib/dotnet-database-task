using DatabaseTask.EF;
using DatabaseTask.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseTask.Controllers
{
    public class StudentController : Controller
    {
        StudentMsBsp26Context db;
        public StudentController(StudentMsBsp26Context db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();

            TempData["Msg"] = s.Name + " created successfully";
            return RedirectToAction("Index");
        }


    }
}
