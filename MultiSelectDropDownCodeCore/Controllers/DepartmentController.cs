using Microsoft.AspNetCore.Mvc;
using MultiSelectDropDownCodeCore.Data;
using MultiSelectDropDownCodeCore.Models;

namespace MultiSelectDropDownCodeCore.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public DepartmentController(EmployeeDbContext employeeDbContext) // for dependency inject here
        {
             _employeeDbContext = employeeDbContext;
        }
        #region Display Department
        public IActionResult Index()
        {
            var data = _employeeDbContext.departments.ToList();
            return View(data);
        }
        #endregion

        #region Add Department
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dpt)
        {
            _employeeDbContext.departments.Add(dpt);
            _employeeDbContext.SaveChanges();   
            return RedirectToAction("Index");
        }
        #endregion
        #region Edit Department
        public IActionResult Edit(int? id)
        {
            var data = _employeeDbContext.departments.Where(x=>x.DepartmentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Department dpt)
        {
            _employeeDbContext.departments.Update(dpt);
            _employeeDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Details Department
        public IActionResult Details(int? id)
        {
            var data = _employeeDbContext.departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            return View(data);
        }
        #endregion

        #region Delete Department
        public IActionResult Delete(int? id)
        {
            var data = _employeeDbContext.departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Delete(Department dpt)
        {
            _employeeDbContext.departments.Remove(dpt);
            _employeeDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
