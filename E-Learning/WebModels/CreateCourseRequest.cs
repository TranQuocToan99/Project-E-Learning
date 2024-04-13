using System.ComponentModel.DataAnnotations;

namespace E_Learning.WebModels
{
    public class CreateCourseRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
