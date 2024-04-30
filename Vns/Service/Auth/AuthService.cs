using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vns.Context;
using Vns.Model.StudentModel;

namespace Vns.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly StudentContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(StudentContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Model.StudentModel.Student> Register(StudentDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

            var user = new Model.StudentModel.Student
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Password = passwordHash,
                Role = request.Role,
            };
            _context.Students.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<string> Login(UserLoginData request)
        {
            var user = _context.Students.FirstOrDefault(u => u.Name == request.Name);
            var result = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            
            string token = CreateToken(user);
            return token;
        }

        public string CreateToken(Model.StudentModel.Student user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
