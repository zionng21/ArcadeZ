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
    public class EnterprisesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnterprisesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Enterprises
        [HttpGet]
        public async Task<IActionResult> GetEnterprises()
        {
            var enterprises = await _unitOfWork.Enterprises.GetAll();
            return Ok(enterprises);
        }

        // GET: api/Enterprises/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnterprise(int id)
        {
            var enterprise = await _unitOfWork.Enterprises.Get(q => q.Id == id);
            
            if(enterprise == null)
            {
                return NotFound();
            }

            return Ok(enterprise);
        }

        // PUT: api/Enterprises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnterprise(int id, Enterprise enterprise)
        {
            if (id != enterprise.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Enterprises.Update(enterprise);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await EnterpriseExists(id))
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

        // POST: api/Enterprises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enterprise>> PostEnterprise(Enterprise enterprise)
        {
            await _unitOfWork.Enterprises.Insert(enterprise);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetEnterprise", new { id = enterprise.Id }, enterprise);
        }

        // DELETE: api/Enterprises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnterprise(int id)
        {
            var enterprise = await _unitOfWork.Enterprises.Get(q => q.Id == id);
            if(enterprise == null)
            {
                return NotFound();
            }

            await _unitOfWork.Enterprises.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> EnterpriseExists(int id)
        {
            var enterprise = await _unitOfWork.Enterprises.Get(q => q.Id == id);
            return (enterprise != null);
        }
    }
}
