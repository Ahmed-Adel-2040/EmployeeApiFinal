

namespace Employment.Interfaces
{
    public interface IEmployeeRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T employee);
        Task<bool> UpdateAsync(T employee);
        Task<bool> DeleteAsync(int id);
    }
}
