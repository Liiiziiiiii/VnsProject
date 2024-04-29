using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vns.Context;
using Vns.Model;
using Vns.Service.Student;

namespace Vns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IStudentService _studentService;


        public StudentsController(StudentContext context, IStudentService stusentService)
        {
            _context = context;
            _studentService = stusentService;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            return await _studentService.GetById(id);
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            return await _studentService.CreateAsync(student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteAsync(id);

            return NoContent();
        }

        private bool StudentExists(int id) => _context.Students.Any(e => e.Id == id);


        [HttpPost("register")]
        public async Task<ActionResult<Student>> Register(StudentDto request)
        {
            try
            {
                return await _studentService.Register(request);

                //return CreatedAtAction(nameof(GetStudent), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("login")]
        public ActionResult<Student> Login(UserLoginData request)
        {
            var user = _context.Students.FirstOrDefault(u => u.Name == request.Name);

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return BadRequest("Wrong password.");
            }

            return Ok(user.Id);
        }
    }
}
