using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoreLecture.Models;

namespace WebApiCoreLecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        readonly EmployeeContext _context;
        public DesignationController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDesignation>>> GetTblDesignation()
        {
            return await _context.TblDesignation.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblDesignation>> GetTblDesignation(int id)
        {
            TblDesignation tblDesignation = await _context.TblDesignation.FindAsync(id);
            if (tblDesignation == null)
            {
                return NotFound();
            }

            return tblDesignation;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TblDesignation>> PutTblDesignation(int id, TblDesignation tblDesignation)
        {
            if (id != tblDesignation.Id)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<TblDesignation>> PostTblDesignation(TblDesignation tblDesignation)
        {
            await _context.TblDesignation.AddAsync(tblDesignation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEmployee", new { id = tblDesignation.Id }, tblDesignation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TblDesignation>> DeleteTblDesignation(int id)
        {
            TblDesignation designation = await _context.TblDesignation.FindAsync(id);
            if (designation == null)
            {
                return NotFound();
            }

            _context.TblDesignation.Remove(designation);
            await _context.SaveChangesAsync();
            return designation;
        }
    }
}
