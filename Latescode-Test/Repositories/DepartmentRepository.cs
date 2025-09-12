using Latescode_Test.Data;
using Latescode_Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Latescode_Test.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _cache;
        private const string AllDepartmentsCacheKey = "departments_all";
        public DepartmentRepository(AppDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            if (!_cache.TryGetValue(AllDepartmentsCacheKey, out IEnumerable<Department> departments))
            {
                departments = await _context.Departments.Include(d => d.Employees).ToListAsync();
                _cache.Set(AllDepartmentsCacheKey, departments);
            }
            return departments;
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            string cacheKey = $"department_{id}";
            if (!_cache.TryGetValue(cacheKey, out Department department))
            {
                department = await _context.Departments.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id == id);
                if (department != null)
                {
                    _cache.Set(cacheKey, department);
                }
            }
            return department;
        }

        public async Task<Department> AddAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            _cache.Remove(AllDepartmentsCacheKey);
            return department;
        }

        public async Task<Department> UpdateAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            _cache.Remove(AllDepartmentsCacheKey);
            _cache.Remove($"department_{department.Id}");
            return department;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return false;
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            _cache.Remove(AllDepartmentsCacheKey);
            _cache.Remove($"department_{id}");
            return true;
        }
    }
}