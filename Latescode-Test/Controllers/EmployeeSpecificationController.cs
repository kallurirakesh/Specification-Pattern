using Latescode_Test.Models;
using Latescode_Test.Repositories;
using Latescode_Test.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Latescode_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeSpecificationController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeSpecificationController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("in-it-department")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesInITDepartment()
        {
            var spec = new EmployeeInITDepartmentSpecification();
            var employees = await _repository.GetBySpecificationAsync(spec);
            return Ok(employees);
        }
    }
}