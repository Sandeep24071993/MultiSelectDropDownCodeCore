using Microsoft.EntityFrameworkCore;
using MultiSelectDropDownCodeCore.Models;

namespace MultiSelectDropDownCodeCore.Data
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
                
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
