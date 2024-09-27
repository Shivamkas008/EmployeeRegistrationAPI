using EmployeeRegistrationAPI.Models;

namespace EmployeeRegistrationAPI.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(int id);

        Task<int> CreateAsync(Department department);
        Task<bool> DeleteAsync(Department department);
       
        void UpdateAsync(Department department);
    }
}
