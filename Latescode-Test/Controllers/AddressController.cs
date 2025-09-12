using Latescode_Test.Models;
using Latescode_Test.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Latescode_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repository;
        public AddressController(IAddressRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAll()
        {
            var addresses = await _repository.GetAllAsync();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetById(int id)
        {
            var address = await _repository.GetByIdAsync(id);
            if (address == null) return NotFound();
            return Ok(address);
        }

        [HttpPost]
        public async Task<ActionResult<Address>> Add(Address address)
        {
            var created = await _repository.AddAsync(address);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> Update(int id, Address address)
        {
            if (id != address.Id) return BadRequest();
            var updated = await _repository.UpdateAsync(address);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}