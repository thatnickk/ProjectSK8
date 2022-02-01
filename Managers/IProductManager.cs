using ProiectSK8.Entities;
using ProiectSK8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Managers
{
    public interface IProductManager
    {
        List<Product> GetPr();
        Product GetPrById(string id);
        Task Create(Product pr);
        Task Update(ProductModel pr);
        Task Delete(string id);
    }
}
