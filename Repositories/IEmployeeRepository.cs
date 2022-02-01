using ProiectSK8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Repositories
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetEmployees();
        Task Create(Employee emp);
        Task Update(Employee emp);
        Task Delete(Employee emp);
    }
}
