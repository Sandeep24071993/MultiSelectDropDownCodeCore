using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiSelectDropDownCodeCore.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime JoiningDate { get; set; }
        public ICollection<EmployeeDepartment> Objempdpt { get; set; } = new HashSet<EmployeeDepartment>(); 
        [NotMapped]
        public string[]? DepartmentName { get; set; }
        [NotMapped]
        public List<SelectListItem>? departmentlist { get; set; }
    }
}
