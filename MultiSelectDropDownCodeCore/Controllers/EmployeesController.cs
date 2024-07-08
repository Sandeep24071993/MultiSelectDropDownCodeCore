using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MultiSelectDropDownCodeCore.Data;
using MultiSelectDropDownCodeCore.Models;

namespace MultiSelectDropDownCodeCore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeesController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.employees.Include(x=>x.Objempdpt).ThenInclude(x=>x.department).ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.employees.Include(x=>x.Objempdpt).ThenInclude(x=>x.department)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            var emp = new Employee();
            var department = _context.departments.Select(x=> new SelectListItem()
            {
                Text = x.Name,  
                Value = x.DepartmentId.ToString()
            }).ToList();
            //department.Insert(0, new SelectListItem(text: "-select-", value: "o", selected: true));
            emp.departmentlist = department;
            return View(emp);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in employee.DepartmentName)
                {
                    int id =0;
                    int.TryParse(item,out id);
                    employee.Objempdpt.Add(new EmployeeDepartment
                    {
                        DepartmentId = id 
                    });
                }
                _context.employees.Add(employee);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.employees.Include(x=>x.Objempdpt).Where(x=>x.EmployeeId==id).FirstOrDefault();
            var selectdpt = employee.Objempdpt.Select(x=>x.DepartmentId).ToList();
            var department = _context.departments.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.DepartmentId.ToString(),
                Selected = selectdpt.Contains(x.DepartmentId)
            }).ToList();
            employee.departmentlist = department;

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var existingempdpt = _context.employees.Include(x=>x.Objempdpt).FirstOrDefault(x=>x.EmployeeId==employee.EmployeeId);
                   foreach (var empdpt in existingempdpt.Objempdpt.ToList()) 
                     _context.Remove(empdpt); 
                   _context.SaveChanges();
                    _context.ChangeTracker.Clear();

                    foreach (var item in employee.DepartmentName)
                    {
                        int id = 0;
                        int.TryParse(item, out id);
                        employee.Objempdpt.Add(new EmployeeDepartment
                        {
                            DepartmentId = id
                        });
                    }
                    _context.employees.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.employees.Include(x=>x.Objempdpt).ThenInclude(x=>x.department)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var existingempdpt = _context.employees.Include(x => x.Objempdpt).FirstOrDefault(x=>x.EmployeeId==id);
            if (existingempdpt != null)
            {
                _context.employees.Remove(existingempdpt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.employees.Any(e => e.EmployeeId == id);
        }
    }
}
