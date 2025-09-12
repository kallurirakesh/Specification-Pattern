using Latescode_Test.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Latescode_Test.Specifications;

namespace Latescode_Test.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Employee>> GetBySpecificationAsync(ISpecification<Employee> specification);
    }
}