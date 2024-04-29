namespace Vns.Model
{
    public class StudentDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
