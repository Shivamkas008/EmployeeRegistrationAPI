using EmployeeRegistrationAPI.Models;

namespace EmployeeRegistrationAPI.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> GetByNameAsync(string name);
        Task<int> CreateAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(Employee employee);
    }
}
