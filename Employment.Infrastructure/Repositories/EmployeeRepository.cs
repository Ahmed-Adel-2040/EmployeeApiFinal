
using Employment.Domain.Entities;
using Employment.Infrastructure.DataContext;
using Employment.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employment.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        // Adds a new employee to the database
        public async Task<Employee> AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        // Deletes an employee by ID
        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        // Retrieves all employees
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        // Retrieves a single employee by ID
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        // Updates an existing employee
        public async Task<bool> UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
