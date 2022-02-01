using ProiectSK8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Context db;

        public ProductRepository(Context db)
        {
            this.db = db;
        }

        public IQueryable<Product> GetProducts()
        {
            var emps = db.Products;
            return emps;
        }
        public async Task Create(Product pr)
        {
            await db.Products.AddAsync(pr);
            await db.SaveChangesAsync();
        }

        public async Task Update(Product pr)
        {
            db.Products.Update(pr);
            await db.SaveChangesAsync();
        }
        public async Task Delete(Product pr)
        {
            db.Products.Remove(pr);
            await db.SaveChangesAsync();
        }
    }
}
