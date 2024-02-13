using EntityFramework2.Entity;
using EntityFramework2.Repostory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _Student;
        public StudentController(IStudent student)
        {
            _Student = student;
        }


        [HttpGet("ALL")]
        public IActionResult GetAllStudents()
        {
            return Ok(_Student.GetStudent());
        }


        [HttpGet("BY ID")]
        public IActionResult GetStudentByID(int id) 
        {
            return Ok(_Student.GetStudentByid(id));
        }


        [HttpGet("Filter By Age")]
        public IActionResult FintStudentbyAge(int MinAge, int MaxAge)
        {
            return Ok(_Student.InBetWeenAge(MinAge, MaxAge));
        }


        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentsDto student)
        {
            _Student.AddStudent(student);
            return Ok("NEW STUDENT ADDED SUCCESFULLY");
        }


        [HttpPut]
        public IActionResult UpdateStudent(int id , [FromBody] StudentsDto studentsDto)
        {
            _Student.UpdateStudent(id, studentsDto);
            return Ok("UPDATED");
        }


        [HttpDelete]
        public IActionResult DeleteStudent(int id) 
        {
            _Student.DeleteStudent(id);
            return Ok("DELETED");
        }
    }
}
