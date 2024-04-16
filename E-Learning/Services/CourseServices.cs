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
                    Id = newCourse.Id,
                    Title = newCourse.Title
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
                    Id = targetCourse.Id,
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
                    Id = targetCourse.Id,
                    Title = targetCourse.Title,
                };
            }
            return null;
        }

        public static GetStudentJoinedCourseResponse GetStudentsJoinedCourse(string courseId)
        {
            var studentsJoinedCourse = Storage.Database.studentsJoinedCourse;
            var students = Storage.Database.students;
            var studentsMapping = students.ToDictionary(x => x.Id, x => x.Name);
            var studentJoined = new GetStudentJoinedCourseResponse();

            var studentsId = studentsJoinedCourse
                .Where(x => x.CouresId == courseId)
                .Select(x => x.StudentId)
                .ToList();

            foreach (var studentId in studentsId)
            {
                if (studentsMapping.ContainsKey(studentId))
                {
                    var student = new StudentResponse()
                    {
                        Id = studentId,
                        Name = studentsMapping[studentId]
                    };
                    studentJoined.StudentsJoined.Add(student);  
                }
            }
            return studentJoined;
        }
    }
}
