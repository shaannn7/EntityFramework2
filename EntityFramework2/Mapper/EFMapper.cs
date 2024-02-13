using AutoMapper;
using EntityFramework2.Entity;

namespace EntityFramework2.Mapper
{
    public class EFMapper:Profile
    {
        public EFMapper()
        {
            CreateMap<Students, StudentsDto>().ReverseMap();
            CreateMap<Course,CourseDto>().ReverseMap();
        }
    }
}
