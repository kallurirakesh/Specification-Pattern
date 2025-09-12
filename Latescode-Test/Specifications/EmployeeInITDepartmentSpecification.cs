using Latescode_Test.Models;

namespace Latescode_Test.Specifications
{
    public class EmployeeInITDepartmentSpecification : Specification<Employee>
    {
        public override System.Linq.Expressions.Expression<System.Func<Employee, bool>> Criteria =>
            e => e.Department != null && e.Department.Name == "IT";
    }
}