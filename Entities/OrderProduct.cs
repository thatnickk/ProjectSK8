using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Entities
{
    public class OrderProduct
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
