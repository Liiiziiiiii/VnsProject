using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Vns.Model;

namespace Vns.Context
{
    public class StudentContext: DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> options) :
            base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}
