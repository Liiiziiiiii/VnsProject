using System;
using Vns.Context;
using Vns.Model.StudentModel;
using Vns.Service.Student;

namespace VnsTest
{
    public class IStudentRepositoryMock
    {
        public static IStudentService GetMock()
        {
            List<Student> lstUser = GenerateTestData();
            StudentContext dbContextMock = DbContextMock.GetMock<Student, StudentContext>(lstUser, x => x.Students);
            return new StudentService(dbContextMock);
        }

        private static List<Student> GenerateTestData()
        {
            List<Student> lstUser = new();
            for (int index = 1; index <= 10; index++)
            {
                lstUser.Add(new Student
                {
                    Id = index,
                    Name = "User-" + index,
                    Password = "12345678"

                });
            }
            return lstUser;
        }
    }
}
