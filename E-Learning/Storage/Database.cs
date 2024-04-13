using E_Learning.Models;

namespace E_Learning.Storage
{
    public class Database
    {
        public static List<Student> students = new List<Student>()
        {
            new Student(){
                Id = "1",
                Name = "Toan",
                DOB = new DateTime(1999, 05, 07),
                Address = "Tay Ninh",
                IsDeleted= false},

            new Student(){
                Id = "2",
                Name = "Cuong",
                DOB = new DateTime(1998, 01, 05),
                Address = "Vung Tau",
                IsDeleted = false},
        };

        public static List<Teacher> teachers = new List<Teacher>()
        {
            new Teacher(){
                Id = "1",
                Name = "Phuc",
                DOB = new DateTime(1978, 02, 17),
                Address = "Ben Tre",
                IsDeleted= false},

            new Teacher(){
                Id = "2",
                Name = "Dung",
                DOB = new DateTime(1989, 05, 20),
                Address = "Ha Noi",
                IsDeleted = false},
        };

        public static List<Course> courses = new List<Course>()
        {
            new Course(){
                Id = "1",
                Title = "Lap trinh co ban",
                IsDeleted= false
            },

           new Course(){
                Id = "2",
                Title = "Giai thuat & cau truc du lieu",
                IsDeleted= false
            },

            new Course(){
                Id = "3",
                Title = "Nhap mon lap trinh",
                IsDeleted= false
            },

            new Course(){
                Id = "4",
                Title = "Lap trinh web",
                IsDeleted= false
            },
        };

        public static List<StudentJoinedCourse> studentJoinedCourses = new List<StudentJoinedCourse>()
        {
            new StudentJoinedCourse(){
                Id = "1",
                StudentId = "1", // Toan
                CouresId = "1", // lap trinh co ban
                TeacherId = "1" // Phuc
            },

            new StudentJoinedCourse(){
                Id = "2",
                StudentId = "2", //Cuong
                CouresId = "2", // Giai thuat
                TeacherId = "1" // Phuc
            },

              new StudentJoinedCourse(){
                Id = "3",
                StudentId = "1",
                CouresId = "2",
                TeacherId = "2"
            },

            new StudentJoinedCourse(){
                Id = "4",
                StudentId = "2",
                CouresId = "2",
                TeacherId = "2"
            },
        };
    }
}
