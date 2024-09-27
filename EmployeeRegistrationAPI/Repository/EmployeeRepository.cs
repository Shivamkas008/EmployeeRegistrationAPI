using EmployeeRegistrationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationAPI.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly EmpDatabaseContext context;

        public EmployeeRepository(EmpDatabaseContext context)
        {
            this.context = context;   
        }

        public async Task<int> CreateAsync(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return employee.EmployeeId;

        }

        public async Task<bool> DeleteAsync(Employee employee)
        {
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return true;
        }


        public async Task<List<Employee>> GetAllAsync()
        {
            var data = await context.Employees
                                    .Include(e => e.Department)
                                    .Include(e => e.Gender)
                                    .Include(e => e.Salutation)
                                    .ToListAsync();
            return data;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {

            var data = await context.Employees.Include(e => e.Department)
                                    .Include(e => e.Gender)
                                    .Include(e => e.Salutation).Where(employee => employee.EmployeeId == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Employee> GetByNameAsync(string name)
        {
            var data = await context.Employees.Include(e => e.Department)
                                    .Include(e => e.Gender)
                                    .Include(e => e.Salutation).Where(employee => employee.DisplayName.Contains(name.ToLower())).FirstOrDefaultAsync();
            return data;
        }
        public async Task<Employee> UpdateAsync(Employee employee)
        {
            var trackedEntity = context.Employees.Include(e => e.Department)
                                    .Include(e => e.Gender)
                                    .Include(e => e.Salutation).FirstOrDefault(d => d.EmployeeId == employee.EmployeeId);

            if (trackedEntity != null)
            {
                context.Entry(trackedEntity).State = EntityState.Detached;
            }
            var data = context.Employees.Update(employee);
           
            await context.SaveChangesAsync();
            var updatedEmployee = await context.Employees
            .Include(e => e.Department)
            .Include(e => e.Gender)
            .Include(e => e.Salutation)
            .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
             return updatedEmployee;
            
        }
    }
}
