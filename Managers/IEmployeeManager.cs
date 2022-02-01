using ProiectSK8.Entities;
using ProiectSK8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Managers
{
    public interface IEmployeeManager
    { 
        List<Employee> GetEmp();
        Employee GetEmpById(string id);
        Task Create(Employee emp);
        Task Update(EmployeeModel client);
        Task Delete(string id);
    }
}
