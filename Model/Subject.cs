using System.ComponentModel.DataAnnotations;
using Vns.Model.SubjectTaskModel;

namespace Vns.Model
{
    public class Subject
    {
        [Key]
        public int Id {get; set;}
        public string Name { get; set; }

        public ICollection<ReferenseTask> ListTasks { get; set; }

        public ICollection<SubjectTaskModel.SubjectTask> Tasks { get; set; }



    }
}
