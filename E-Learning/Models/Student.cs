using System.ComponentModel.DataAnnotations;
namespace E_Learning.Models
{
    public class Student
    {
        [Required]
        public string? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Address { get; set; }

        public bool IsDeleted { get; set; }
    }
}