using ProiectSK8.Entities;
using ProiectSK8.Models;
using ProiectSK8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Managers
{
    public class ProductManager : IProductManager
    {
        private IProductRepository repo;
        public ProductManager(IProductRepository prRepository)
        {
            this.repo = prRepository;
        }

        public async Task Create(Product pr)
        {
            await repo.Create(pr);
        }

        public async Task Update(ProductModel pr1)
        {
            var pr = repo.GetProducts().FirstOrDefault(x => x.Id == pr1.Id);
            pr.Name = pr1.Name;
            pr.Category = pr1.Category;
            pr.Quantity = pr1.Quantity;
            await repo.Update(pr);

        }

        public Product GetPrById(string id)
        {
            var pr = repo.GetProducts().FirstOrDefault(x => x.Id == id);
            return pr;
        }

        public async Task Delete(string id)
        {
            var pr = GetPrById(id);
            await repo.Delete(pr);
        }

        public List<Product> GetPr()
        {
            return repo.GetProducts().ToList();
        }
    }
}
