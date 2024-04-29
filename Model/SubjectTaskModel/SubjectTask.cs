using System.ComponentModel.DataAnnotations;

namespace Vns.Model.SubjectTaskModel
{
    public class SubjectTask
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Question> Question { get; set; }

    }
}
