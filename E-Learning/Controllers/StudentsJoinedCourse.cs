using E_Learning.Models;
using E_Learning.Services;
using E_Learning.WebModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsJoinedCourse : ControllerBase
    {

        private readonly ILogger<StudentsJoinedCourse> _logger;

        public StudentsJoinedCourse(ILogger<StudentsJoinedCourse> logger)
        {
            _logger = logger;
        }

        [HttpPost("course-registration")]
        public IActionResult CourseRegistration([FromBody] CourseRegistrationRequest request)
        {
            return Ok();
        }
    }
}
