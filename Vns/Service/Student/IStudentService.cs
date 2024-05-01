using Microsoft.AspNetCore.Mvc;

namespace Vns.Service.Student;

public interface IStudentService
    {
        Task<Model.StudentModel.Student> GetById(int id);
        Task<Model.StudentModel.Student> CreateAsync(Model.StudentModel.Student student);
        Task<Model.StudentModel.Student> UpdateAsync(int id, Model.StudentModel.Student student);
        Task<bool> DeleteAsync(int id);
        
    }
