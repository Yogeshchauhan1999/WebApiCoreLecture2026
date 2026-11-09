using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoreLecture.Models;

namespace WebApiCoreLecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly EmployeeContext _context;
        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEmployee>>> GetTblEmployees()
        {
            var employee = (from e in _context.TblEmployees
                            join d in _context.TblDesignation
                            on e.DesignationID equals d.Id

                            select new TblEmployee
                            {
                                Id = e.Id,
                                Name = e.Name,
                                LastName = e.LastName,
                                Email=e.Email,
                                Gender=e.Gender,
                                DesignationID=d.Id,
                                DOJ = e.DOJ,
                                Designation=d.Designation,
                                Age=e.Age,
                                IsActive=e.IsActive,
                                IsMarried=e.IsMarried
                            }
                         ).ToListAsync();
            return await employee;


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblEmployee>> GetTblEmployee(int id)
        {
            TblEmployee tblEmployee = await _context.TblEmployees.FindAsync(id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            return tblEmployee;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TblEmployee>> PutTblEmployee(int id,TblEmployee tblEmployee)
        {
            if(id!=tblEmployee.Id)
            {
                return BadRequest();
            }
            return Ok();    
        }

        [HttpPost]
        public async Task<ActionResult<TblEmployee>> PostTblEmployee(TblEmployee tblEmployee)
        {
           await _context.TblEmployees.AddAsync(tblEmployee);
           await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEmployee", new { id = tblEmployee.Id }, tblEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TblEmployee>> DeleteTblEmployee(int id)
        {
          TblEmployee employee= await _context.TblEmployees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.TblEmployees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }


    }
}
