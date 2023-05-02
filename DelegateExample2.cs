using System;
using First_Csharp;
using MyClasses.Models;

namespace First_Csharp.Basic_and_OOP
{

    public class Test_Main
    {
        public static void Main(String[] args)
        {
            var managment = new StudentsManagment();
            var stu = new Student[]
            {
                new Student {name="Stu1",  id=22018054,  chapter_work=40, final=60},
                new Student {name="Stu2",  id=22018023,  chapter_work=20, final=45},
                new Student {name="Stu3",  id=22018023,  chapter_work=410, final=48},
                new Student {name="Stu4",  id=22018056,  chapter_work=25, final=53},
                new Student {name="Stu5",  id=22018067,  chapter_work=40, final=36},
                new Student {name="Stu6",  id=22018089,  chapter_work=40, final=25},
                new Student {name="Stu7",  id=22018097,  chapter_work=17, final=34},
                new Student {name="Stu8",  id=22018055,  chapter_work=19, final=12},
                new Student {name="Stu9",  id=22018067,  chapter_work=15, final=46},
                new Student {name="Stu10", id=22018087,  chapter_work=40, final=35},
                new Student {name="Stu11", id=22018086,  chapter_work=30, final=54},
                new Student {name="Stu12", id=22018021,  chapter_work=35, final=40},
                new Student {name="Stu13", id=22018034,  chapter_work=20, final=35},
                new Student {name="Stu14", id=22018043,  chapter_work=12, final=60},
                new Student {name="Stu15", id=22018053,  chapter_work=23, final=65},
                new Student {name="Stu16", id=22018077,  chapter_work=19, final=25},
                new Student {name="Stu17", id=22018089,  chapter_work=33, final=40},
                new Student {name="Stu18", id=22018090,  chapter_work=40, final=25},
                new Student {name="Stu19", id=22018078,  chapter_work=24, final=55},
                new Student {name="Stu20", id=22018043,  chapter_work=39, final=40},
                new Student {name="Stu21", id=22018055,  chapter_work=5,  final=60},
                new Student {name="Stu22", id=22018066,  chapter_work=8,  final=46},
            };

            managment.StudentsFilter(stu, "Excellent Students",Excellent);
            Console.WriteLine("\n\n");
            managment.StudentsFilter(stu, "Very Good Students",VeryGood);
            Console.WriteLine("\n\n");
			      managment.StudentsFilter(stu, "Good Students", Good);
            Console.WriteLine("\n\n");
			      managment.StudentsFilter(stu, "Pass Students", Pass);
			      Console.WriteLine("\n\n");
			      managment.StudentsFilter(stu, "Faild Student", Fail);

            Console.ReadKey();
        }
        public static bool Excellent(Student s) => s.GetTotal()>=85 && s.GetTotal()<=100;
        public static bool VeryGood(Student s) => s.GetTotal()>=75 && s.GetTotal()<85;
        public static bool Good(Student s) => s.GetTotal()>=65 && s.GetTotal()<75;
        public static bool Pass(Student s) => s.GetTotal()>=50 && s.GetTotal() <65;
        public static bool Fail(Student s) => s.GetTotal()>=0 && s.GetTotal() <50;
    }
    
    public class StudentsManagment
    {
        public delegate bool Stufounder(Student stu);
        public void StudentsFilter(Student[] students,string? title,Stufounder isStufounder)
        {
            Console.WriteLine(title);
            Console.WriteLine("******************************");
            foreach (var stu in students)
            {
                if(isStufounder(stu))
                    Console.WriteLine(stu);
            }
        }
		
	}
    public class Student
    {
        public string? name { get; set; }
        public int id { get; set; }
        public double chapter_work { get; set; }
        public double final { get; set; }
        public double GetTotal() => chapter_work+final>100? 0: chapter_work+final;
		public override string? ToString()
		{
            return $"Name:{name}, Id:{id}, Total:{GetTotal()}";
		}
	}
}
