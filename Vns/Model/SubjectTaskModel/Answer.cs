
namespace Vns.Model.SubjectTaskModel
{
    public class Answer
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public bool Correct {  get; set; }

        public short Mark { get; set; }
    }
}
