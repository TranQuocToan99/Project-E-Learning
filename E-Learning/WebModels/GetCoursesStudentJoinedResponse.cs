namespace E_Learning.WebModels
{
    public class GetCoursesStudentJoinedResponse
    {
        public List<CourseResponse> CoursesJoins { get; set; } = new List<CourseResponse>();
    }

    public class CourseResponse { 
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
