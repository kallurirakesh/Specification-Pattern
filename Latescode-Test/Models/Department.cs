using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Latescode_Test.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}