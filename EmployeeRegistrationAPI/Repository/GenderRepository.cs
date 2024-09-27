using EmployeeRegistrationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationAPI.Repository
{
    public class GenderRepository:IGenderRepository
    {
        private readonly EmpDatabaseContext context;
        public GenderRepository(EmpDatabaseContext context)
        {
            this.context = context;  
        }

        public async Task<int> CreateAsync(Gender gender)
        {
            context.Genders.Add(gender);
            
            await context.SaveChangesAsync();
            return gender.GenderId;
        }

        public async Task<bool> DeleteAsync(Gender gender)
        {
            
            context.Genders.Remove(gender);
            
            await context.SaveChangesAsync();
            return true;

        }

       
        public async Task<List<Gender>> GetAllAsync()
        {
           
           return await context.Genders.ToListAsync();
        }

        public async Task<Gender> GetByIdAsync(int id)
        {
            return await context.Genders.Where(gender => gender.GenderId == id).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(Gender gender)
        {

            var trackedEntity = context.Genders.FirstOrDefault(d => d.GenderId == gender.GenderId);

            if (trackedEntity != null)
            {
                context.Entry(trackedEntity).State = EntityState.Detached;
            }
            context.Genders.Update(gender);
            
            await context.SaveChangesAsync();
            return gender.GenderId;
        }
    }
}
