namespace MultiSelectDropDownCodeCore.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeDepartment> Objempdpt { get; set; }

    }
}
