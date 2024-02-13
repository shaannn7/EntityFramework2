using EntityFramework2.Entity;

namespace EntityFramework2.Repostory
{
    public interface IStudent
    {
        public List<StudentsDto> GetStudent();
        public StudentsDto GetStudentByid(int id);
        public void AddStudent(StudentsDto student);
        public void UpdateStudent(int id,StudentsDto student);
        public void DeleteStudent(int id);
        public List<StudentsDto> InBetWeenAge(int MinAge, int MaxAge);
    }
}
