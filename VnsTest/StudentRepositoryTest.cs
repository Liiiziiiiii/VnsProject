using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vns.Model;
using Vns.Model.StudentModel;
using Vns.Service.Student;

namespace VnsTest
{
    public class StudentRepositoryTest
    {
        private IStudentService studentRepository;

        [SetUp]
        public void SetUp()
        {
            studentRepository = IStudentRepositoryMock.GetMock();
        }

       

        [Test]
        public async Task GetEmployeeById()
        {
            //Arrange
            int id = 1;

            //Act
            Student data = await studentRepository.GetById(id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(data, Is.Not.Null);
                Assert.That(data.Id, Is.EqualTo(id));
            });
        }

        [Test]
        public async Task AddEmployee()
        {
            // Arrange
            Student student = new Student()
            {
                Id = 0,
                Name = "string",
                Surname = "string",
                Email = "string",
                Password = "string",
                Role = "string",
                Subjects = new List<Subject>()
            };

            // Act
            await studentRepository.CreateAsync(student);
            Student expectedData = await studentRepository.GetById(student.Id);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(expectedData, Is.Not.Null);
                Assert.That(expectedData.Id, Is.EqualTo(student.Id));
            });
        }

        [Test]
        public async Task DeleteEmployee()
        {
            // Arrange
            int id = 2;

            // Act
            bool deletionResult = await studentRepository.DeleteAsync(id);
            Student expectedData = await studentRepository.GetById(id);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deletionResult, Is.True);
                Assert.That(expectedData, Is.Null);
            });
        }



    }
}
