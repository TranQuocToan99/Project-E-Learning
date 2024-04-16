using E_Learning.Models;
using E_Learning.WebModels;
using Microsoft.OpenApi.Validations;

namespace E_Learning.Services
{
    public class TeacherServices
    {
        public static List<Teacher> GetAllTeacher()
        {
            return Storage.Database.teachers;
        }

        public static CreateTeacherResponse CreateTeacher(CreateTeacherRequest request)
        {
            var teachers = Storage.Database.teachers;

            var newTeacher = new Teacher()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                DOB = request.DOB,
                Address = request.Address,
                IsDeleted = false
            };
            teachers.Add(newTeacher);

            return new CreateTeacherResponse()
            {
                Id = newTeacher.Id,
                Name = newTeacher.Name,
                DOB = newTeacher.DOB,
                Address = newTeacher.Address,
            };
        }

        public static UpdateTeacherResponse UpdateTeacher(UpdateTeacherRequest request, string teacherId)
        {
            var teachers = Storage.Database.teachers;

            var targetTeacher = teachers
                .FirstOrDefault(x => x.Id == teacherId);
            if (targetTeacher != null)
            {
                var newTeacher = new Teacher()
                {
                    Id = targetTeacher.Id,
                    Name = request.Name,
                    DOB = request.DOB,
                    Address = request.Address,
                    IsDeleted = targetTeacher.IsDeleted,
                };
                teachers.Remove(targetTeacher);
                teachers.Add(newTeacher);

                return new UpdateTeacherResponse()
                {
                    Name = newTeacher.Name,
                    DOB = newTeacher.DOB,
                    Address = newTeacher.Address,
                };
            }
            return null;
        }

        public static DeleteTeacherResponse DeleteTeacher(string teacherId)
        {
            var teachers = Storage.Database.teachers;

            var targetTeacher = teachers
                .FirstOrDefault(x => x.Id == teacherId);
            if (targetTeacher != null)
            {
                targetTeacher.IsDeleted = true;

                return new DeleteTeacherResponse()
                {
                    Name = targetTeacher.Name,
                    IsDeleted = targetTeacher.IsDeleted
                };
            }
            return null;
        }

        public static GetBioTeacherResponse GetBioTeacher(string teacherId)
        {
            var teachers = Storage.Database.teachers;
            var targetTeacher = teachers
                .FirstOrDefault(x => x.Id == teacherId);
            if (targetTeacher != null)
            {
                return new GetBioTeacherResponse()
                {
                    Name = targetTeacher.Name,
                    DOB = targetTeacher.DOB,
                    Address = targetTeacher.Address,
                };
            }
            return null;
        }

        public static GetCourseTeachResponse GetCourses(string teacherId)
        {
            var studentJoinedCourses = Storage.Database.studentsJoinedCourse;
            var courses = Storage.Database.courses;
            var courseTeacheResponse = new GetCourseTeachResponse();

            var coursesId = studentJoinedCourses
                .Where(x => x.TeacherId == teacherId)
                .Select(x => x.CouresId)
                .ToList();

            foreach (var courseId in coursesId)
            {
                var getCourse = courses
                     .FirstOrDefault(x => x.Id == courseId);
                if (getCourse != null)
                {
                    var course = new CourseTeachResponse()
                    {
                        Id = getCourse.Id,
                        Title = getCourse.Title,
                    };
                    courseTeacheResponse.CoursesTeach.Add(course);
                }
            }
            return courseTeacheResponse;
        }

        public static GetStudentsInCourseResponse GetStudentsInCourse(GetStudentInCourseRequest request, string teacherId)
        {
            var studentJoinedCourses = Storage.Database.studentsJoinedCourse;
            var courses = Storage.Database.courses;
            var students = Storage.Database.students;
            var getStudentsInCourseResponse = new GetStudentsInCourseResponse();

            var getCourse = courses
              .FirstOrDefault(x => x.Id == request.CouresId);
            if (getCourse != null)
            {
                getStudentsInCourseResponse.CourseId = getCourse.Id;
                getStudentsInCourseResponse.CourseTitle = getCourse.Title;
            }

            var studentsId = studentJoinedCourses
                .Where(x => x.TeacherId == teacherId)
                .Select(x => x.StudentId)
                .ToList();
            foreach (var studentId in studentsId)
            {
                var getStudent = students
                    .FirstOrDefault(x => x.Id == studentId);
                if (getStudent != null)
                {
                    var student = new StudentInCourseRespons()
                    {
                        Id = getStudent.Id,
                        Name = getStudent.Name,
                        DOB = getStudent.DOB
                    };
                    getStudentsInCourseResponse.StudentsInCourse.Add(student);
                }
            }
            return getStudentsInCourseResponse;
        }
    }
}