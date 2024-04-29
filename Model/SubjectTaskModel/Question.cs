namespace Vns.Model.SubjectTaskModel
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Answer> Answer { get; set; }
    }
}
