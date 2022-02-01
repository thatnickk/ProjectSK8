using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Entities
{
    public class Order
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public DateTime Date { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
