
using ClassModels;

namespace Application1
{
    public class NestedType
    {
        public static void Main(string[] args)
        {
            Student student1 =new Student("","",1,new List<Student.Course>{
                new Student.Course("",""),
                new Student.Course("",""),
                new Student.Course("",""),
                new Student.Course("","I")
            });
            Student student2 =new Student("","",2,new List<Student.Course>{
                new Student.Course("",""),
                new Student.Course("",""),
                new Student.Course("",""),
                new Student.Course("","")
            });

            Console.WriteLine(student1);
            foreach (Student.Course stu in student1.Courses)
            {
                System.Console.WriteLine($"\t{stu.ToString()}");
            }
            Console.WriteLine(student2);
            foreach (Student.Course stu in student2.Courses)
            {
                System.Console.WriteLine($"\t{stu.ToString()}");
            }
        }
    }
    public class Student
    {
        private string? _fname {get; set;}
        private string? _lname {get; set;}
        private int  _id { get; set; }
        public string? GetName
        {
            get=> _fname+" "+_lname;
        }
        public void SetName(string fname,string lname)
        {
            _fname=fname;
            _lname=lname;
        }

        public int Id
        {
            get=> _id;
            set=> _id=value;
        }
        private List<Course> _courses {get; set;}
        public List<Course> Courses
        {
            get => _courses;
            set =>_courses=value;
        }
        public class Course
        {
            public string? Name {get; set;}
            public string? Id {get; set;}
            public Course(string? Name, string? Id)
            {
                this.Name=Name;
                this.Id=Id;
            }
            public override string ToString()
            {
                return $"Course[Name:{Name} Id:{Id}]";
            }

        }// End of class Course

        public Student(string? fname, string? lname,int id, List<Course> courses)
        {
            _fname = fname;
            _lname = lname;
            _id = id;
            _courses=courses;
        }
        public override string? ToString()
        {
            return $"Student\nName:{GetName} Id:{_id}]";
        }
    }
}
