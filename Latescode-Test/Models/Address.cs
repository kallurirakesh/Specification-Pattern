using System.ComponentModel.DataAnnotations;

namespace Latescode_Test.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}