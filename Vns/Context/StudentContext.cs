using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Vns.Model;
using Vns.Model.StudentModel;
using Vns.Model.SubjectTaskModel;

namespace Vns.Context
{
    public class StudentContext : DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> options) :
            base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SubjectTask> SubjectTasks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Question>()
        //        .HasOne(q => q.Answer)
        //        .WithMany()
        //        .HasForeignKey(q => q.AnswerId);

        ////    modelBuilder.Entity<SubjectTask>()
        ////       .HasOne(q => q.Question)
        ////       .WithMany()
        ////       .HasForeignKey(q => q.QuestionId);
        //}


        





    }
}
