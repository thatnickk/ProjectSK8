using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectSK8.Entities;
using ProiectSK8.Managers;
using ProiectSK8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductManager manager;

        public ProductController(IProductManager pr)
        {
            this.manager = pr;
        }

        [HttpGet]

        public async Task<IActionResult> GetPrs()
        {
            var prs = manager.GetPr();
            return Ok(prs);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var pr = manager.GetPrById(id);

            return Ok(pr);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductModel pr)
        {
            var newPr = new Product
            {
                Id = pr.Id,
                Name = pr.Name,
                Category = pr.Category,
                Quantity = pr.Quantity
            };

            await manager.Create(newPr);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductModel pr)
        {
            await manager.Update(pr);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string pr)
        {
            await manager.Delete(pr);
            return Ok();
        }
    }
}
