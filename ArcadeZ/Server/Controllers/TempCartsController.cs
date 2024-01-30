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
    public class TempCartsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TempCartsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/TempCarts
        [HttpGet]
        public async Task<IActionResult> GetTempCarts()
        {
            var tempCarts = await _unitOfWork.TempCarts.GetAll(includes: q=>q.Include(x=>x.ProductHardware).Include(x=>x.ProductSoftware));
            return Ok(tempCarts);
        }

        // GET: api/TempCarts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTempCart(int id)
        {
            var tempCart = await _unitOfWork.TempCarts.Get(q => q.Id == id);
            
            if(tempCart == null)
            {
                return NotFound();
            }

            return Ok(tempCart);
        }

        // PUT: api/TempCarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTempCart(int id, TempCart tempCart)
        {
            if (id != tempCart.Id)
            {
                return BadRequest();
            }

            _unitOfWork.TempCarts.Update(tempCart);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await TempCartExists(id))
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

        // POST: api/TempCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TempCart>> PostTempCart(TempCart tempCart)
        {
            await _unitOfWork.TempCarts.Insert(tempCart);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTempCart", new { id = tempCart.Id }, tempCart);
        }

        // DELETE: api/TempCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTempCart(int id)
        {
            var tempCart = await _unitOfWork.TempCarts.Get(q => q.Id == id);
            if(tempCart == null)
            {
                return NotFound();
            }

            await _unitOfWork.TempCarts.Delete(id);
			await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> TempCartExists(int id)
        {
            var tempCart = await _unitOfWork.TempCarts.Get(q => q.Id == id);
            return (tempCart != null);
        }
    }
}
