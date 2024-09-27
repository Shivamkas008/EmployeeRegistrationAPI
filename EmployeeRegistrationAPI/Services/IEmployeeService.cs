using EmployeeRegistrationAPI.Models;

namespace EmployeeRegistrationAPI.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllAsync();
        Task<EmployeeDTO> GetByIdAsync(int id);
        Task<EmployeeDTO> GetByNameAsync(string name);
        Task CreateAsync(EmployeeDTO model);
        Task<Employee> UpdateAsync(EmployeeUpdateDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
