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

              new Student(){
                Id = "3",
                Name = "Quy",
                DOB = new DateTime(2000, 04, 30),
                Address = "Ha Tinh",
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

        public static List<StudentJoinedCourse> studentsJoinedCourse = new List<StudentJoinedCourse>()
        {
            new StudentJoinedCourse(){
                Id = "1",
                StudentId = "1",
                CouresId = "1",
                TeacherId = "1"
            },

            new StudentJoinedCourse(){
                Id = "2",
                StudentId = "2",
                CouresId = "2",
                TeacherId = "1"
            },

              new StudentJoinedCourse(){
                Id = "3",
                StudentId = "3",
                CouresId = "2",
                TeacherId = "1"
            },

            new StudentJoinedCourse(){
                Id = "4",
                StudentId = "2",
                CouresId = "2",
                TeacherId = "2"
            },
        };

        public static List<Schedule> schedules = new List<Schedule>()
        {
             new Schedule() {
                 Id = "1",
                CourseId = "1",
                Day = Day.Monday,
                Section = Section.Section1,
                TypeClass = Classify.Theory
             },

              new Schedule() {
                 Id = "2",
                CourseId = "1",
                Day = Day.Tuesday,
                Section = Section.Section1,
                TypeClass = Classify.Pratice
             },

             new Schedule() {
                 Id = "3",
                CourseId = "2",
                Day = Day.Tuesday,
                Section = Section.Section2,
                TypeClass = Classify.Theory
             },


        };
    }
}
