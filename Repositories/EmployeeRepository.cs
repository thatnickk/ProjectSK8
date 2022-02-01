using ProiectSK8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private Context db;

        public EmployeeRepository(Context db)
        {
            this.db = db;
        }

        public IQueryable<Employee> GetEmployees()
        {
            var emps = db.Employees;
            return emps;
        }
        public async Task Create(Employee emp)
        {
            await db.Employees.AddAsync(emp);
            await db.SaveChangesAsync();
        }

        public async Task Update(Employee emp)
        {
            db.Employees.Update(emp);
            await db.SaveChangesAsync();
        }
        public async Task Delete(Employee emp)
        {
            db.Employees.Remove(emp);
            await db.SaveChangesAsync();
        }
    }
}
