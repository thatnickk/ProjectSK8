using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Entities
{
    public class Client
    {
        public string Id { get; set;}
        public string Nume { get; set; }
        public string Telefon { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
