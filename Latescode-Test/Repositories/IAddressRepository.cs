using Latescode_Test.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Latescode_Test.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAsync();
        Task<Address> GetByIdAsync(int id);
        Task<Address> AddAsync(Address address);
        Task<Address> UpdateAsync(Address address);
        Task<bool> DeleteAsync(int id);
    }
}