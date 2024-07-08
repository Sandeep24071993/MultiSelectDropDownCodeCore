namespace MultiSelectDropDownCodeCore.Models
{
    public class EmployeeDepartment
    {
        public int EmployeeDepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public Department department { get; set; }
        public Employee employee { get; set; }
    }
}
