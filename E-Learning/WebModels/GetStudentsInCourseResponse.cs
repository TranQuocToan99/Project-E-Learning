namespace E_Learning.WebModels
{
    public class GetStudentsInCourseResponse
    {
        public string CourseId { get; set; }
        public string CourseTitle { get; set; }
        public List<StudentInCourseRespons> StudentsInCourse { get; set; } = new List<StudentInCourseRespons>();
    }

    public class StudentInCourseRespons { 
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }
}
