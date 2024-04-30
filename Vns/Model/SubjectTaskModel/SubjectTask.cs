using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vns.Model.SubjectTaskModel
{
    public class SubjectTask
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Question_Id")]
        public Question QuestionId { get; set; }
        public ICollection<Question> Question { get; set; }

    }
}
