using EmployeeRegistrationAPI.Models;

namespace EmployeeRegistrationAPI.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDTO>> GetAllAsync();
        Task<DepartmentDTO> GetByIdAsync(int id);
        Task CreateAsync(DepartmentDTO model);
        Task UpdateAsync(DepartmentDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
