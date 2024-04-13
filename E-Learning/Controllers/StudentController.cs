using E_Learning.Services;
using E_Learning.WebModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet("students")]
        public IActionResult Get()
        {
            var students = StudentServices.GetAllStudent();
            if (students != null)
            {
                return Ok(students);
            }
            return NotFound();
        }

        [HttpPost("add-student")]
        public IActionResult Create([FromBody] CreateStudentRequest request)
        {
            var createResponse = StudentServices.CreateStudent(request);
            if (createResponse != null)
            {
                return Ok(createResponse);
            }
            return BadRequest("Adding student fail!");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateStudentRequest request, string studentId)
        {
            var updateResponse = StudentServices.UpdateStudent(request, studentId);
            if (updateResponse != null)
            {
                return Ok(updateResponse);
            }
            return NotFound($"Can be not found this id: {studentId}");
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string studentId)
        {
            var deleteResponse = StudentServices.DeleteStudent(studentId);
            if (deleteResponse != null)
            {
                return Ok(deleteResponse);
            }
            return NotFound($"Can be not found this id: {studentId}");
        }

        [HttpGet("bio-student")]
        public IActionResult GetBioStudent([FromQuery] string studentId)
        {
            var bioResponse = StudentServices.GetBioStudent(studentId);
            if (bioResponse != null)
            {
                return Ok(bioResponse);
            }
            return NotFound($"Can be not found this id: {studentId}");
        }

        [HttpGet("courses-student-joined")]
        public IActionResult GetCoursesStudentJoined([FromQuery] string studentId)
        {
            var courses = StudentServices.GetCoursesStudentJoined(studentId);
            if (courses != null)
            {
                return Ok(courses);
            }
            return NotFound($"Can be not found this id: {studentId}");
        }
    }
}

   
