using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Models
{
    public class EmployeeModel
    {
        public string Id { get; set; }
        public string Nume { get; set; }
        public string ShopId { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
    }
}
