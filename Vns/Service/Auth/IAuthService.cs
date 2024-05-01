using Vns.Model.StudentModel;

namespace Vns.Service.Auth
{
    public interface IAuthService
    {
        Task<Model.StudentModel.Student> Register(StudentDto request);
        Task<string> Login(UserLoginData request);
        string CreateToken(Model.StudentModel.Student user);
    }
}
