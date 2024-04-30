using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vns.Context;
using Vns.Model.StudentModel;
using Vns.Service.Student;

namespace Vns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IStudentService _studentService;
        private readonly IConfiguration _configuration;
        //private readonly ILogger<GlobalExceptionHandler> _logger;


        public StudentsController(StudentContext context, IStudentService stusentService)
        {
            _context = context;
            _studentService = stusentService;
        }

        // GET: api/Students
        [HttpGet, Authorize(Roles = "Student")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}"), Authorize(Roles = "Student")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            return await _studentService.GetById(id);
        }

        // PUT: api/Students/5
        [HttpPut("{id}"), Authorize(Roles = "Student")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            try
            {
                await _studentService.UpdateAsync(id, student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                       
                   
                }
            }

            return NoContent();
        }

        // POST: api/Students
        [HttpPost, Authorize(Roles = "Student")]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            return await _studentService.CreateAsync(student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}"), Authorize(Roles = "Student")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteAsync(id);

            return NoContent();
        }

        private bool StudentExists(int id) => _context.Students.Any(e => e.Id == id);


    }
}
