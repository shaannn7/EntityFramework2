namespace EntityFramework2.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public string CouseName { get; set; }
        public List<Students>Student_d { get; set; }
    }
    public class CourseDto
    {
        public string CouseName { get; set; }
    }
}
