namespace E_Learning.WebModels
{
    public class GetCourseTeachResponse
    {
        public List<CourseTeachResponse> CoursesTeach { get; set; } = new List<CourseTeachResponse>();
    }

    public class CourseTeachResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
 