using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vns.Context;
using Vns.Model.SubjectTaskModel;

namespace Vns.Controllers.TaskController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectTasksController : ControllerBase
    {
        private readonly StudentContext _context;

        public SubjectTasksController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/SubjectTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectTask>>> GetSubjectTasks()
        {
            return await _context.SubjectTasks.ToListAsync();
        }

        // GET: api/SubjectTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectTask>> GetSubjectTask(int id)
        {
            var subjectTask = await _context.SubjectTasks.FindAsync(id);

            if (subjectTask == null)
            {
                return NotFound();
            }

            return subjectTask;
        }

        // PUT: api/SubjectTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectTask(int id, SubjectTask subjectTask)
        {
            if (id != subjectTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectTaskExists(id))
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

        // POST: api/SubjectTasks
        [HttpPost]
        public async Task<ActionResult<SubjectTask>> PostSubjectTask(SubjectTask subjectTask)
        {
            _context.SubjectTasks.Add(subjectTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectTask", new { id = subjectTask.Id }, subjectTask);
        }

        // DELETE: api/SubjectTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectTask(int id)
        {
            var subjectTask = await _context.SubjectTasks.FindAsync(id);
            if (subjectTask == null)
            {
                return NotFound();
            }

            _context.SubjectTasks.Remove(subjectTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectTaskExists(int id)
        {
            return _context.SubjectTasks.Any(e => e.Id == id);
        }
    }
}
