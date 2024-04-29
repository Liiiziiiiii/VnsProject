using Microsoft.AspNetCore.Mvc;
using Vns.Model;

namespace Vns.Service.Student;
    public interface IStudentService
    {
        Task<Student.Student> GetById(int id);
        Task<Student> CreateAsync(Student student);
        Task<Student> UpdateAsync(int id, Student student);
        Task DeleteAsync(int id);
        Task<Student> Register(StudentDto request);
        Task<bool> Login(UserLoginData request);
    }
}
