using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vns.Context;
using Vns.Model.StudentModel;
using Vns.Service.Auth;
using Vns.Service.Student;

namespace Vns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;


        public AuthController(StudentContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Student>> Register(StudentDto request)
        {
            try
            {
                return await _authService.Register(request);

                //return CreatedAtAction(nameof(GetStudent), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("login")]
        public string Login(UserLoginData request)
        {
            var user = _context.Students.FirstOrDefault(u => u.Name == request.Name);

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return "Wrong password.";
            }

            string token = CreateToken(user);

            return token;
        }


        private string CreateToken(Student user)
        {
            return _authService.CreateToken(user);
        }


    }
}
