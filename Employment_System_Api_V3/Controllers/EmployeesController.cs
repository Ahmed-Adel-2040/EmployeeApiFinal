
using Employment.Application.DTOs;
using Employment.Application.Interfaces;
using Employment.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        // GET: api/employees
        // Retrieves all employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get() => Ok(await _service.GetAllAsync());

        // GET: api/employees/{id}
        // Retrieves a specific employee by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        // POST: api/employees
        // Adds a new employee
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(CreateEmployeeDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        // PUT: api/employees/{id}
        // Updates an existing employee
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateEmployeeDto dto)
        {
            if (id != dto.Id) return BadRequest(); // Validate route vs body
            var result = await _service.UpdateAsync(id, dto);
            return result ? NoContent() : NotFound();
        }

        // DELETE: api/employees/{id}
        // Deletes an employee by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
