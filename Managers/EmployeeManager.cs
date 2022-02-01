using ProiectSK8.Entities;
using ProiectSK8.Models;
using ProiectSK8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private IEmployeeRepository repo;
        public EmployeeManager(IEmployeeRepository empRepository)
        {
            this.repo = empRepository;
        }

        public async Task Create(Employee emp)
        {
            await repo.Create(emp);
        }

        public async Task Update(EmployeeModel emp1)
        {
            var emp = repo.GetEmployees().FirstOrDefault(x => x.Id == emp1.Id);
            emp.Nume = emp1.Nume;
            emp.Salary = emp1.Salary;
            emp.HireDate = emp1.HireDate;
            await repo.Update(emp);

        }

        public Employee GetEmpById(string id)
        {
            var emp = repo.GetEmployees().FirstOrDefault(x => x.Id == id);
            return emp;
        }

        public async Task Delete(string id)
        {
            var emp = GetEmpById(id);
            await repo.Delete(emp);
        }

        public List<Employee> GetEmp()
        {
            return repo.GetEmployees().ToList();
        }
    }
}
