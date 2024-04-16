using E_Learning.Services;
using E_Learning.WebModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {

        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ILogger<TeacherController> logger)
        {
            _logger = logger;
        }

        [HttpGet("teachers")]
        public IActionResult Get()
        {
            var teachers = TeacherServices.GetAllTeacher();
            if (teachers != null)
            {
                return Ok(teachers);
            }
            return NotFound();
        }

        [HttpPost("add-teacher")]
        public IActionResult Create([FromBody] CreateTeacherRequest request)
        {
            var createResponse = TeacherServices.CreateTeacher(request);
            if (createResponse != null)
            {
                return Ok(createResponse);
            }
            return BadRequest("Adding student fail!");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateTeacherRequest request, string teacherId)
        {
            var updateResponse = TeacherServices.UpdateTeacher(request, teacherId);
            if (updateResponse != null)
            {
                return Ok(updateResponse);
            }
            return NotFound($"Can be not found this id: {teacherId}");
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string teacherId)
        {
            var deleteResponse = TeacherServices.DeleteTeacher(teacherId);
            if (deleteResponse != null)
            {
                return Ok(deleteResponse);
            }
            return NotFound($"Can be not found this id: {teacherId}");
        }

        [HttpGet("bio-teacher")]
        public IActionResult GetBio([FromQuery] string teacherId)
        {
            var bioResponse = TeacherServices.GetBioTeacher(teacherId);
            if (bioResponse != null)
            {
                return Ok(bioResponse);
            };
            return NotFound($"Can be not found this id: {teacherId}");
        }

        [HttpGet("classes")]
        public IActionResult GetClasses([FromQuery] string teacherId)
        {
            var classesResponse = TeacherServices.GetCourses(teacherId);
            if (classesResponse != null)
            {
                return Ok(classesResponse);
            }
            return NotFound($"Can be not found this id: {teacherId}");
        }

        [HttpGet("students-in-course")]
        public IActionResult GetStudentInCourse([FromQuery] GetStudentInCourseRequest request, string teacherId)
        {
            var studentInCourseResponse = TeacherServices.GetStudentsInCourse(request, teacherId);
            if(studentInCourseResponse != null)
            {
                return Ok(studentInCourseResponse);
            }
            return NotFound($"Can be not found this id: {teacherId}");
        }
    }
}
