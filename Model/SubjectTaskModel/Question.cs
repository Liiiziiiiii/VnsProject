using System.ComponentModel.DataAnnotations.Schema;

namespace Vns.Model.SubjectTaskModel
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("Answer_Id")]
        public Answer Answer { get; set; }
        //public ICollection<Answer> Answer { get; set; }
    }
}
