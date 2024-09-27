using EmployeeRegistrationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationAPI.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly EmpDatabaseContext context;
        public DepartmentRepository(EmpDatabaseContext context)
        {
            this.context = context; 
        }

        public async Task<int> CreateAsync(Department department)
        {
            context.Departments.Add(department);
            await context.SaveChangesAsync();
            return department.DepartmentId;
        }

        public async Task<bool> DeleteAsync(Department department)
        {
            context.Departments.Remove(department);
            await context.SaveChangesAsync();
            return true;
        }

       
        public async Task<List<Department>> GetAllAsync()
        {
            
            return await context.Departments.ToListAsync();
        }

        public async  Task<Department> GetByIdAsync(int id)
        {
            return await context.Departments.Where(department => department.DepartmentId == id).FirstOrDefaultAsync();

        }

        public void UpdateAsync(Department department)
        {
            var trackedEntity = context.Departments.FirstOrDefault(d => d.DepartmentId == department.DepartmentId);

            if (trackedEntity != null)
            {
                context.Entry(trackedEntity).State = EntityState.Detached;
            }

            context.Departments.Update(department);
            context.SaveChangesAsync();
        }
    }
}
