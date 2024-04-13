using E_Learning.Models;
using E_Learning.WebModels;
using E_Learning.WebModelsa;

namespace E_Learning.Services
{
    public class StudentServices
    {
        public static List<Student> GetAllStudent()
        {
            return Storage.Database.students;
        }

        public static CreateStudentResponse CreateStudent(CreateStudentRequest request)
        {
            var students = Storage.Database.students;

            var newStudent = new Student()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                DOB = request.DOB,
                Address = request.Address,
                IsDeleted = false
            };
            students.Add(newStudent);

            return new CreateStudentResponse()
            {
                Id = newStudent.Id,
                Name = newStudent.Name,
                DOB = newStudent.DOB,
                Address = newStudent.Address,
            };
        }

        public static UpdateStudentResponse UpdateStudent(UpdateStudentRequest request, string studentId)
        {
            var students = Storage.Database.students;

            var targetStudent = students
                .FirstOrDefault(x => x.Id == studentId);
            if (targetStudent != null)
            {
                var newStudent = new Student()
                {
                    Id = targetStudent.Id,
                    Name = request.Name,
                    DOB = request.DOB,
                    Address = request.Address,
                    IsDeleted = targetStudent.IsDeleted,
                };
                students.Remove(targetStudent);
                students.Add(newStudent);

                return new UpdateStudentResponse()
                {
                    Name = newStudent.Name,
                    DOB = newStudent.DOB,
                    Address = newStudent.Address,
                };
            }
            return null;
        }

        public static DeleteStudentResponse DeleteStudent(string studentId)
        {
            var students = Storage.Database.students;

            var targetStudent = students
                .FirstOrDefault(x => x.Id == studentId);
            if (targetStudent != null)
            {
                targetStudent.IsDeleted = true;

                return new DeleteStudentResponse()
                {
                    Name = targetStudent.Name,
                    IsDeleted = targetStudent.IsDeleted
                };
            }
            return null;
        }

        public static GetBioStudentResponse GetBioStudent(string studentId)
        {
            var students = Storage.Database.students;
            var targetStudent = students
                .FirstOrDefault(x => x.Id == studentId);
            if (targetStudent != null)
            {
                return new GetBioStudentResponse()
                {
                    Name = targetStudent.Name,
                    DOB = targetStudent.DOB,
                    Address = targetStudent.Address,
                };
            }
            return null;
        }

        public static GetCoursesStudentJoinedResponse GetCoursesStudentJoined(string studentId)
        {
            var studentJoinedCourses = Storage.Database.studentJoinedCourses;
            var courses = Storage.Database.courses;
            var  courseJoined = new GetCoursesStudentJoinedResponse();

            var targetCouresId = studentJoinedCourses
                .Where(x => x.StudentId == studentId)
                .Select(x => x.CouresId)
                .ToList();

            foreach (var courseId in targetCouresId)
            {
                var getCourse = courses
                    .FirstOrDefault(x => x.Id == courseId);
                if (getCourse != null)
                {
                    var course = new CourseResponse
                    {
                        Id = getCourse.Id,
                        Title = getCourse.Title
                    };
                    courseJoined.CoursesJoins.Add(course);
                }
            }
            return courseJoined;
        }
    }
}