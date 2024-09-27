using EmployeeRegistrationAPI.Models;

namespace EmployeeRegistrationAPI.Repository
{
    public interface IGenderRepository
    {
        Task<List<Gender>> GetAllAsync();
        Task<Gender> GetByIdAsync(int id);
        Task<int> CreateAsync(Gender gender);
        Task<int> UpdateAsync(Gender gender);
        Task<bool> DeleteAsync(Gender gender);
    }
}
