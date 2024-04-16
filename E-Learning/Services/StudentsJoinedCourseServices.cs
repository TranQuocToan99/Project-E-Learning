using E_Learning.WebModels;

namespace E_Learning.Services
{
    public class StudentsJoinedCourseServices
    {
        public static CourseRegistrationResponse CourseRegistration(CourseRegistrationRequest request) {
            var studentsJoinedCourse = Storage.Database.studentsJoinedCourse;
            var schedules = Storage.Database.schedules;

            var coursesId = studentsJoinedCourse
                .Where(x => x.StudentId == request.StudentId)
                .Select(x => x.CouresId)
                .ToList();



            return null;
        }
    }
}



