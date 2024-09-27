using EmployeeRegistrationAPI.Models;

namespace EmployeeRegistrationAPI.Services
{
    public interface ISalutationService
    {
        Task<List<SalutationDTO>> GetAllAsync();
        Task<SalutationDTO> GetByIdAsync(int id);
        Task CreateAsync(SalutationDTO model);
        Task UpdateAsync(SalutationDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
