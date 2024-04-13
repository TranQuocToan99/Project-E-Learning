using System.ComponentModel.DataAnnotations;

namespace E_Learning.WebModels
{
    public class CreateStudentRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
