using E_Learning.Models;
using E_Learning.Services;
using E_Learning.WebModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }

        [HttpGet("courses")]
        public IActionResult Get()
        {
            var coursesResponse = CourseServices.GetAllCourse();
            if (coursesResponse != null)
            {
                return Ok(coursesResponse);
            }
            return BadRequest();
        }

        [HttpPost("create-course")]
        public IActionResult Create([FromBody] CreateCourseRequest request)
        {
            var createResponse = CourseServices.CreateCourse(request);
            if (createResponse != null)
            {
                return Ok(createResponse);
            }
            return BadRequest("Adding student fail!");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateCourseRequest request, string courseId)
        {
            var updateResponse = CourseServices.UpdateCourse(request, courseId);
            if (updateResponse != null)
            {
                return Ok(updateResponse);
            }
            return NotFound($"Can be not found this id: {courseId}");
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string courseId)
        {
            var deleteResponse = CourseServices.DeleteCourse(courseId);
            if (deleteResponse != null)
            {
                return Ok(deleteResponse);
            }
            return NotFound($"Can be not found this id: {courseId}");
        }

        [HttpGet("bio-course")]
        public IActionResult GetBio([FromQuery] string courseId)
        {
            var bioCourseResponse = CourseServices.GetBioCourse(courseId);
            if (bioCourseResponse != null)
            {
                return Ok(bioCourseResponse);
            }
            return NotFound($"Can be not found this id: {courseId}");
        }

        [HttpGet("students-joined-course")]
        public IActionResult GetStudentsJoinedCourse([FromQuery] string courseId)
        {
            var studentRespone = CourseServices.GetStudentsJoinedCourse(courseId);
            if(studentRespone != null)
            {
                return Ok(studentRespone);
            }
            return NotFound($"Can be not found this id: {courseId}");
        }
    }
}
