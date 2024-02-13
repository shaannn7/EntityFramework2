using AutoMapper;
using EntityFramework2.Data;
using EntityFramework2.Entity;
using EntityFramework2.Repostory;

namespace EntityFramework2.Services
{
    public class CourseRepostory : ICourse
    {
        private readonly DbContextClass _dbContextClass;
        private readonly IMapper _mapper;
        public CourseRepostory(DbContextClass dbContextClass, IMapper mapper)
        {
            _dbContextClass = dbContextClass;
            _mapper = mapper;
        }

        public void AddCourse(CourseDto courseDto)
        {
          var CRS =_mapper.Map<Course>(courseDto);
            _dbContextClass.Course.Add(CRS);
            _dbContextClass.SaveChanges();
        }
    }
}
