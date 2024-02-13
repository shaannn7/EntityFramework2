using AutoMapper;
using EntityFramework2.Data;
using EntityFramework2.Entity;
using EntityFramework2.Mapper;
using EntityFramework2.Repostory;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework2.Services
{
    public class StudentRepostory:IStudent
    {
        private readonly DbContextClass _dbContextClass;
        private readonly IMapper _mapper;
        public StudentRepostory(DbContextClass dbContextClass,IMapper mapper)
        {
            _dbContextClass = dbContextClass;
            _mapper = mapper;
        }
        public List<StudentsDto> GetStudent()
        {
            var std = _dbContextClass.Student.Include(i => i.Course).ToList();
            var all = std.Select(i => new StudentsDto
            {
                StudentId = i.Id,
                StudentName = i.StudentName,
                StudentAge = i.StudentAge,
                CourseId = i.CourseId,
                CourseName = i.Course.CouseName
            }).ToList();
            return all;
            
        }

        public StudentsDto GetStudentByid(int id)
        {
            var findSTD = _dbContextClass.Student.Include(i=>i.Course).FirstOrDefault(x=>x.Id==id);
            return new StudentsDto { StudentId = findSTD.Id,StudentName=findSTD.StudentName,StudentAge=findSTD.StudentAge,CourseId=findSTD.CourseId,CourseName=findSTD.Course.CouseName};
        }
        public List<StudentsDto> InBetWeenAge(int MinAge, int MaxAge)
        {
            var find = _dbContextClass.Student.Include(i => i.Course).Where(x => x.StudentAge > MinAge && x.StudentAge < MaxAge).ToList();
            var all = find.Select(x => new StudentsDto
            {
                StudentId = x.Id, StudentName = x.StudentName, StudentAge = x.StudentAge,CourseId = x.CourseId,CourseName = x.Course.CouseName
            }).ToList();
            return all;
        }

        public void AddStudent(StudentsDto studentdto)
        {
            var STD = _mapper.Map<Students>(studentdto);
            _dbContextClass.Student.Add(STD);
            _dbContextClass.SaveChanges();
            
        }
        public void UpdateStudent(int id ,StudentsDto student)
        {
           var find = _dbContextClass.Student.Include(i=>i.Course).FirstOrDefault(x=>x.Id==id);
              find.StudentName= student.StudentName;
              find.StudentAge= student.StudentAge; 
              find.CourseId= student.CourseId;
            find.Course.CouseName = student.CourseName;
            _dbContextClass.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var fin = _dbContextClass.Student.Include(i => i.Course).FirstOrDefault(i=>i.Id==id);
            _dbContextClass.Remove(fin);
            _dbContextClass.SaveChanges();
        }
    }
}
