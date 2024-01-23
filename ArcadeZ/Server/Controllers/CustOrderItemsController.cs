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
    public class CustOrderItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustOrderItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/CustOrderItems
        [HttpGet]
        public async Task<IActionResult> GetCustOrderItems()
        {
            var custOrderItems = await _unitOfWork.CustOrderItems.GetAll(includes: q=>q.Include(x=>x.ProductHardware).Include(x=>x.ProductSoftware).Include(x=>x.CustOrder));
            return Ok(custOrderItems);
        }

        // GET: api/CustOrderItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustOrderItem(int id)
        {
            var custOrderItem = await _unitOfWork.CustOrderItems.Get(q => q.Id == id);
            
            if(custOrderItem == null)
            {
                return NotFound();
            }

            return Ok(custOrderItem);
        }

        // PUT: api/CustOrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustOrderItem(int id, CustOrderItem custOrderItem)
        {
            if (id != custOrderItem.Id)
            {
                return BadRequest();
            }

            _unitOfWork.CustOrderItems.Update(custOrderItem);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await CustOrderItemExists(id))
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

        // POST: api/CustOrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustOrderItem>> PostCustOrderItem(CustOrderItem custOrderItem)
        {
            await _unitOfWork.CustOrderItems.Insert(custOrderItem);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCustOrderItem", new { id = custOrderItem.Id }, custOrderItem);
        }

        // DELETE: api/CustOrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustOrderItem(int id)
        {
            var custOrderItem = await _unitOfWork.CustOrderItems.Get(q => q.Id == id);
            if(custOrderItem == null)
            {
                return NotFound();
            }

            await _unitOfWork.CustOrderItems.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> CustOrderItemExists(int id)
        {
            var custOrderItem = await _unitOfWork.CustOrderItems.Get(q => q.Id == id);
            return (custOrderItem != null);
        }
    }
}
