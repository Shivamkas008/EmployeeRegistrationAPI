using EmployeeRegistrationAPI.Models;

namespace EmployeeRegistrationAPI.Services
{
    public interface IGenderService
    {
        Task<List<GenderDTO>> GetAllAsync();
        Task<GenderDTO> GetByIdAsync(int id);
        Task CreateAsync(GenderDTO model);
        Task UpdateAsync(GenderDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
