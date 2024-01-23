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
    public class CustEnquiriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustEnquiriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/CustEnquires
        [HttpGet]
        public async Task<IActionResult> GetCustEnquiries()
        {
            var custEnquiries = await _unitOfWork.CustEnquiries.GetAll(includes: q => q.Include(x=>x.Customer).Include(x=>x.Staff));
            return Ok(custEnquiries);
        }

        // GET: api/CustEnquires/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff(int id)
        {
            var custEnquiry = await _unitOfWork.CustEnquiries.Get(q => q.Id == id);
            
            if(custEnquiry == null)
            {
                return NotFound();
            }

            return Ok(custEnquiry);
        }

        // PUT: api/CustEnquires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, CustEnquiry custEnquiry)
        {
            if (id != custEnquiry.Id)
            {
                return BadRequest();
            }

            _unitOfWork.CustEnquiries.Update(custEnquiry);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await StaffExists(id))
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

        // POST: api/CustEnquires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustEnquiry>> PostStaff(CustEnquiry custEnquiry)
        {
            await _unitOfWork.CustEnquiries.Insert(custEnquiry);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetStaff", new { id = custEnquiry.Id }, custEnquiry);
        }

        // DELETE: api/CustEnquires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var custEnquiry = await _unitOfWork.CustEnquiries.Get(q => q.Id == id);
            if(custEnquiry == null)
            {
                return NotFound();
            }

            await _unitOfWork.CustEnquiries.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> StaffExists(int id)
        {
            var custEnquiry = await _unitOfWork.CustEnquiries.Get(q => q.Id == id);
            return (custEnquiry != null);
        }
    }
}
