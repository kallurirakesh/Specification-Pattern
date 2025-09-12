using Latescode_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Latescode_Test.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Engineering" },
                new Department { Id = 2, Name = "HR" }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Alice Smith", Position = "Developer", Salary = 80000, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Bob Johnson", Position = "Manager", Salary = 95000, DepartmentId = 1 },
                new Employee { Id = 3, Name = "Carol Lee", Position = "QA Engineer", Salary = 70000, DepartmentId = 2 }
            );
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Street = "123 Main St", City = "Metropolis", State = "NY", ZipCode = "10001", EmployeeId = 1 },
                new Address { Id = 2, Street = "456 Oak Ave", City = "Gotham", State = "NJ", ZipCode = "07001", EmployeeId = 2 },
                new Address { Id = 3, Street = "789 Pine Rd", City = "Star City", State = "CA", ZipCode = "90001", EmployeeId = 3 }
            );
        }
    }
}