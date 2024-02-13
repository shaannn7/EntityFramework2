using System.ComponentModel.DataAnnotations;

namespace EntityFramework2.Entity
{
    public class Students
    {
        [Key]
        public int  Id { get; set; }
        public string StudentName { get; set;}
        public int StudentAge { get; set;}
        public int CourseId { get; set;}
        public Course Course { get; set;}
    }

    public class StudentsDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }

    }


}
