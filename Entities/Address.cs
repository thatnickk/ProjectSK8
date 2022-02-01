using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Entities
{
    public class Address
    {
        public string Id { get; set; }
        public string ShopId { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
