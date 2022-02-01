using ProiectSK8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> GetProducts();
        Task Create(Product pr);
        Task Update(Product pr);
        Task Delete(Product pr);
    }
}
