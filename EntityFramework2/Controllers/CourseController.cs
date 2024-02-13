using EntityFramework2.Entity;
using EntityFramework2.Repostory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _course;
        public CourseController(ICourse course)
        {
            _course = course;
        }

        [HttpPost]
        public IActionResult AddCouse(CourseDto course)
        {
            _course.AddCourse(course);
            return Ok("COURSE ADDED SUCCEFULLY");
        }
    }
}
