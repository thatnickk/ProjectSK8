using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectSK8.Entities;
using ProiectSK8.Managers;
using ProiectSK8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeManager manager;

        public EmployeeController(IEmployeeManager emp)
        {
            this.manager = emp;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetEmps()
        {
            var emps = manager.GetEmp();
            return Ok(emps);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var emp = manager.GetEmpById(id);

            return Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeModel emp)
        {
            var newEmp = new Employee
            {
                Id = emp.Id,
                Nume = emp.Nume,
                ShopId = emp.ShopId,
                Salary = emp.Salary,
                HireDate = emp.HireDate
            };

            await manager.Create(newEmp);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmployeeModel emp)
        {
            await manager.Update(emp);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string emp)
        {
            await manager.Delete(emp);
            return Ok();
        }
    }
}
