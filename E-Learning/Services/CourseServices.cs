using E_Learning.Models;
using E_Learning.WebModels;

namespace E_Learning.Services
{
    public class CourseServices
    {
        public static List<Course> GetAllCourse()
        {
            return Storage.Database.courses;
        }

        public static CreateCourseResponse CreateCourse(CreateCourseRequest request)
        {
            var courses = Storage.Database.courses;

            var newCourse = new Course()
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                IsDeleted = false
            };
            courses.Add(newCourse);

            return new CreateCourseResponse()
            {
                Id = newCourse.Id,
                Title = newCourse.Title
            };
        }

        public static UpdateCourseResponse UpdateCourse(UpdateCourseRequest request, string courseId)
        {
            var courses = Storage.Database.courses;

            var targetCourse = courses
                .FirstOrDefault(x => x.Id == courseId);
            if (targetCourse != null)
            {
                var newCourse = new Course()
                {
                    Id = targetCourse.Id,
                    Title = request.Title,
                    IsDeleted = targetCourse.IsDeleted,
                };
                courses.Remove(targetCourse);
                courses.Add(newCourse);

                return new UpdateCourseResponse()
                {
                    Title = newCourse.Title,
                };
            }
            return null;
        }

        public static DeleteCourseResponse DeleteCourse(string courseId)
        {
            var courses = Storage.Database.courses;

            var targetCourse = courses
                .FirstOrDefault(x => x.Id == courseId);
            if (targetCourse != null)
            {
                targetCourse.IsDeleted = true;

                return new DeleteCourseResponse()
                {
                    Title = targetCourse.Title,
                    IsDeleted = targetCourse.IsDeleted
                };
            }
            return null;
        }

        public static GetBioCourseResponse GetBioCourse(string courseId)
        {
            var courses = Storage.Database.courses;
            var targetCourse = courses
                .FirstOrDefault(x => x.Id == courseId);
            if (targetCourse != null)
            {
                return new GetBioCourseResponse()
                {
                    Title = targetCourse.Title,
                };
            }
            return null;
        }

        public static GetStudentJoinedCourseResponse GetStudentJoinedJoinedCourse(string courseId)
        {
            var studentJoinedCourses = Storage.Database.studentJoinedCourses;
            var students = Storage.Database.students;
            var studentJoined = new GetStudentJoinedCourseResponse();

            var targetStudentsId = studentJoinedCourses
                .Where(x => x.CouresId == courseId)
                .Select(x => x.StudentId)
                .ToList();

            foreach (var studentId in targetStudentsId)
            {
                var getStudent = students
                    .FirstOrDefault(x => x.Id == studentId);
                if (getStudent != null)
                {
                    var student = new StudentResponse()
                    {
                        Id = getStudent.Id,
                        Name = getStudent.Name
                    };
                    studentJoined.StudentsJoined.Add(student);
                }
            }
            return studentJoined;
        }
    }
}
