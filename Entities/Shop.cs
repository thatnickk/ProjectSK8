using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Entities
{
    public class Shop
    {
        public string Id { get; set; }
        public double StorageCapacity { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
