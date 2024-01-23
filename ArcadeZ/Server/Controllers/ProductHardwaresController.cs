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
    public class ProductHardwaresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductHardwaresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ProductHardwares
        [HttpGet]
        public async Task<IActionResult> GetProductHardwares()
        {
            var productHardwares = await _unitOfWork.ProductHardwares.GetAll(includes: q => q.Include(x => x.Enterprise));
            return Ok(productHardwares);
        }

        // GET: api/ProductHardwares/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductHardware(int id)
        {
            var productHardware = await _unitOfWork.ProductHardwares.Get(q => q.Id == id);
            
            if(productHardware == null)
            {
                return NotFound();
            }

            return Ok(productHardware);
        }

        // PUT: api/ProductHardwares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductHardware(int id, ProductHardware productHardware)
        {
            if (id != productHardware.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ProductHardwares.Update(productHardware);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await ProductHardwareExists(id))
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

        // POST: api/ProductHardwares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductHardware>> PostProductHardware(ProductHardware productHardware)
        {
            await _unitOfWork.ProductHardwares.Insert(productHardware);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetProductHardware", new { id = productHardware.Id }, productHardware);
        }

        // DELETE: api/ProductHardwares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductHardware(int id)
        {
            var productHardware = await _unitOfWork.ProductHardwares.Get(q => q.Id == id);
            if(productHardware == null)
            {
                return NotFound();
            }

            await _unitOfWork.ProductHardwares.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ProductHardwareExists(int id)
        {
            var productHardware = await _unitOfWork.ProductHardwares.Get(q => q.Id == id);
            return (productHardware != null);
        }
    }
}
