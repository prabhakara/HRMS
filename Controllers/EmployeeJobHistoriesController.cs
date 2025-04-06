using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMSystemWebAPI.Models;

namespace HRMSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeJobHistoriesController : ControllerBase
    {
        private readonly HrmsContext _context;
        private readonly ILogger<EmployeeJobHistoriesController> _logger;
        public EmployeeJobHistoriesController(HrmsContext context, ILogger<EmployeeJobHistoriesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/EmployeeJobHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeJobHistory>>> GetEmployeeJobHistories()
        {
            return await _context.EmployeeJobHistories.ToListAsync();
        }

        // GET: api/EmployeeJobHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeJobHistory>> GetEmployeeJobHistory(int id)
        {
            var employeeJobHistory = await _context.EmployeeJobHistories.FindAsync(id);

            if (employeeJobHistory == null)
            {
                return NotFound();
            }

            return employeeJobHistory;
        }

        // PUT: api/EmployeeJobHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeJobHistory(int id, EmployeeJobHistory employeeJobHistory)
        {
            if (id != employeeJobHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeJobHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeJobHistoryExists(id))
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

        // POST: api/EmployeeJobHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeJobHistory>> PostEmployeeJobHistory(EmployeeJobHistory employeeJobHistory)
        {
            _context.EmployeeJobHistories.Add(employeeJobHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeJobHistory", new { id = employeeJobHistory.Id }, employeeJobHistory);
        }

        // DELETE: api/EmployeeJobHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeJobHistory(int id)
        {
            var employeeJobHistory = await _context.EmployeeJobHistories.FindAsync(id);
            if (employeeJobHistory == null)
            {
                return NotFound();
            }

            _context.EmployeeJobHistories.Remove(employeeJobHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeJobHistoryExists(int id)
        {
            return _context.EmployeeJobHistories.Any(e => e.Id == id);
        }
    }
}
