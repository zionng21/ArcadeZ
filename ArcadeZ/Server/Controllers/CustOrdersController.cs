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
    public class CustOrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustOrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/CustOrders
        [HttpGet]
        public async Task<IActionResult> GetCustOrders()
        {
            var custOrders = await _unitOfWork.CustOrders.GetAll(includes: q=>q.Include(x=>x.Customer).Include(x=>x.Staff));
            return Ok(custOrders);
        }

        // GET: api/CustOrders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustOrder(int id)
        {
            var custOrder = await _unitOfWork.CustOrders.Get(q => q.Id == id);
            
            if(custOrder == null)
            {
                return NotFound();
            }

            return Ok(custOrder);
        }

        // PUT: api/CustOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustOrder(int id, CustOrder custOrder)
        {
            if (id != custOrder.Id)
            {
                return BadRequest();
            }

            _unitOfWork.CustOrders.Update(custOrder);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await CustOrderExists(id))
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

        // POST: api/CustOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustOrder>> PostCustOrder(CustOrder custOrder)
        {
            await _unitOfWork.CustOrders.Insert(custOrder);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCustOrder", new { id = custOrder.Id }, custOrder);
        }

        // DELETE: api/CustOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustOrder(int id)
        {
            var custOrder = await _unitOfWork.CustOrders.Get(q => q.Id == id);
            if(custOrder == null)
            {
                return NotFound();
            }

            await _unitOfWork.CustOrders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> CustOrderExists(int id)
        {
            var custOrder = await _unitOfWork.CustOrders.Get(q => q.Id == id);
            return (custOrder != null);
        }
    }
}
