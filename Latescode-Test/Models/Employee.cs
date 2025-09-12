using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Latescode_Test.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Address>? Addresses { get; set; }
    }
}