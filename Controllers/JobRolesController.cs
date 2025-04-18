﻿using System;
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
    public class JobRolesController : ControllerBase
    {
        private readonly HrmsContext _context;
        private readonly ILogger<JobRolesController> _logger;
        public JobRolesController(HrmsContext context, ILogger<JobRolesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/JobRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobRole>>> GetJobRoles()
        {
            return await _context.JobRoles.ToListAsync();
        }

        // GET: api/JobRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobRole>> GetJobRole(int id)
        {
            var jobRole = await _context.JobRoles.FindAsync(id);

            if (jobRole == null)
            {
                return NotFound();
            }

            return jobRole;
        }

        // PUT: api/JobRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobRole(int id, JobRole jobRole)
        {
            if (id != jobRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobRoleExists(id))
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

        // POST: api/JobRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobRole>> PostJobRole(JobRole jobRole)
        {
            _context.JobRoles.Add(jobRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobRole", new { id = jobRole.Id }, jobRole);
        }

        // DELETE: api/JobRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobRole(int id)
        {
            var jobRole = await _context.JobRoles.FindAsync(id);
            if (jobRole == null)
            {
                return NotFound();
            }

            _context.JobRoles.Remove(jobRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobRoleExists(int id)
        {
            return _context.JobRoles.Any(e => e.Id == id);
        }
    }
}
