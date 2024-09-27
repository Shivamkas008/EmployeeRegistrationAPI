using EmployeeRegistrationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationAPI.Repository
{
    public class SalutationRepository:ISalutationRepository
    {
        private readonly EmpDatabaseContext context;
        public SalutationRepository(EmpDatabaseContext context)
        {
            this.context = context; 
        }

        public async Task<int> CreateAsync(Salutation salutation)
        {
           context.Salutations.Add(salutation);
           await context.SaveChangesAsync();
            return salutation.SalutationId;
        }

        public async Task<bool> DeleteAsync(Salutation salutation)
        {
            context.Salutations.Remove(salutation);
            await context.SaveChangesAsync();
            return true;

        }

        
        public async  Task<List<Salutation>> GetAllAsync()
        {
            return await context.Salutations.ToListAsync();
        }
    

        public async Task<Salutation> GetByIdAsync(int id)
        {
            var data = await context.Salutations.Where(salutation => salutation.SalutationId == id).FirstOrDefaultAsync();
            return data;

        }

        public async Task<int> UpdateAsync(Salutation salutation)
        {
            var trackedEntity = context.Salutations.FirstOrDefault(d => d.SalutationId == salutation.SalutationId);

            if (trackedEntity != null)
            {
                context.Entry(trackedEntity).State = EntityState.Detached;
            }
            context.Salutations.Update(salutation);
            await context.SaveChangesAsync();
           return salutation.SalutationId;
        }
    }
}
