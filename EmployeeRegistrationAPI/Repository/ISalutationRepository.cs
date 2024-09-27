using EmployeeRegistrationAPI.Models;

namespace EmployeeRegistrationAPI.Repository
{
    public interface ISalutationRepository
    {
        Task<List<Salutation>> GetAllAsync();
        Task<Salutation> GetByIdAsync(int id);
        Task<int> CreateAsync(Salutation salutation);
        Task<int> UpdateAsync(Salutation salutation);
        Task<bool> DeleteAsync(Salutation salutation);
      
    }
}
