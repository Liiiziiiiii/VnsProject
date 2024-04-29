using Microsoft.EntityFrameworkCore;
using Vns.Context;
using Vns.Model;

namespace Vns.Service.Student
{
    public class StudentService : IStudentService
    {
        private readonly StudentContext _context;

        public StudentService(StudentContext context)
        {
            _context = context;
        }

        public async Task<Model.Student> CreateAsync(Student student)
        {
            _context.Students.Add(student);

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> UpdateAsync(int id, Student student)
        {
            _context.Entry(student).State = EntityState.Modified;


            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student> Register(StudentDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

            var user = new Student
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Password = passwordHash,
            };

            _context.Students.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Login(UserLoginData request)
        {
            var user = _context.Students.FirstOrDefault(u => u.Name == request.Name);
            var result = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            //TODO: token
            return true;
        }
    }
}
