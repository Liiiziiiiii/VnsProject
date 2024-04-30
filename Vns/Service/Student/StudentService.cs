using Microsoft.EntityFrameworkCore;
using Vns.Context;

namespace Vns.Service.Student
{
    public class StudentService : IStudentService
    {
        private readonly StudentContext _context;

        public StudentService(StudentContext context)
        {
            _context = context;
        }

        public async Task<Model.StudentModel.Student> CreateAsync(Model.StudentModel.Student student)
        {
            _context.Students.Add(student);

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();


            return true;
        }

        public async Task<Model.StudentModel.Student> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Model.StudentModel.Student> UpdateAsync(int id, Model.StudentModel.Student student)
        {
            _context.Entry(student).State = EntityState.Modified;


            await _context.SaveChangesAsync();

            return student;
        }

        
    }
}
