using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Entities
{
    public class Employee
    {
        public string Id { get; set; }
        public string Nume { get; set; }    
        public string ShopId { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
