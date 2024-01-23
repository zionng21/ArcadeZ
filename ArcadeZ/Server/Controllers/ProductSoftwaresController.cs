using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArcadeZ.Server.Data;
using ArcadeZ.Shared.Domain;
using ArcadeZ.Server.IRepository;

namespace ArcadeZ.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSoftwaresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductSoftwaresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ProductSoftwares
        [HttpGet]
        public async Task<IActionResult> GetProductSoftwares()
        {
            var productSoftwares = await _unitOfWork.ProductSoftwares.GetAll();
            return Ok(productSoftwares);
        }

        // GET: api/ProductSoftwares/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductSoftware(int id)
        {
            var productSoftware = await _unitOfWork.ProductSoftwares.Get(q => q.Id == id);
            
            if(productSoftware == null)
            {
                return NotFound();
            }

            return Ok(productSoftware);
        }

        // PUT: api/ProductSoftwares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSoftware(int id, ProductSoftware productSoftware)
        {
            if (id != productSoftware.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ProductSoftwares.Update(productSoftware);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await ProductSoftwareExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductSoftwares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductSoftware>> PostProductSoftware(ProductSoftware productSoftware)
        {
            await _unitOfWork.ProductSoftwares.Insert(productSoftware);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetProductSoftware", new { id = productSoftware.Id }, productSoftware);
        }

        // DELETE: api/ProductSoftwares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductSoftware(int id)
        {
            var productSoftware = await _unitOfWork.ProductSoftwares.Get(q => q.Id == id);
            if(productSoftware == null)
            {
                return NotFound();
            }

            await _unitOfWork.ProductSoftwares.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ProductSoftwareExists(int id)
        {
            var productSoftware = await _unitOfWork.ProductSoftwares.Get(q => q.Id == id);
            return (productSoftware != null);
        }
    }
}
