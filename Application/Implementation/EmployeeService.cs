using Employment.Application.DTOs;
using Employment.Application.Interfaces;
using Employment.Domain.Entities;
using Employment.Interfaces;



namespace Employment.Application.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository<Employee> _repository;

        // Inject the repository to access data layer
        public EmployeeService(IEmployeeRepository<Employee> repository)
        {
            _repository = repository;
        }

        // Retrieves all employees from the database
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // Retrieves a specific employee by ID
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // Creates a new employee using data from the DTO
        public async Task<Employee> CreateAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Position = dto.Position,
                Department = dto.Department,
                Salary = dto.Salary,
                JoiningDate = dto.JoiningDate
            };

            return await _repository.AddAsync(employee);
        }

        // Updates an existing employee by ID using data from the DTO
        public async Task<bool> UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            // Update fields
            existing.Name = dto.Name;
            existing.Position = dto.Position;
            existing.Department = dto.Department;
            existing.Salary = dto.Salary;
            existing.JoiningDate = dto.JoiningDate;

            return await _repository.UpdateAsync(existing);
        }

        // Deletes an employee by ID
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
