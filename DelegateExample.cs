using MyClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Csharp.Basic_and_OOP
{
	public class DelegateExample
	{
		public static void Main(String[] args)
		{


			var emp = new EMP[]
			{
				new EMP { Id=1, Name="Mohammed", Gender="M" ,TotalSales=70000m },
				new EMP { Id=2, Name="Ahmed", Gender="M" ,TotalSales=12000m },
				new EMP { Id=3, Name="Ali", Gender="M" ,TotalSales=50000m },
				new EMP { Id=4, Name="Taha", Gender="M" ,TotalSales=30000m },
				new EMP { Id=5, Name="Mustafa", Gender="M" ,TotalSales=16000m },
				new EMP { Id=6, Name="Omar", Gender="M" ,TotalSales=80000m },
				new EMP { Id=7, Name="Abdullah", Gender="M" ,TotalSales=90000m },
				new EMP { Id=8, Name="Khaled", Gender="M" ,TotalSales=44000m }
			};
			var report = new Reports();
			report.ProcessEmployee(emp, "Employee With Sales >= $60000", emp => emp.TotalSales>=60000);
			Console.WriteLine("\n\n");
			report.ProcessEmployee(emp, "Employee With Sales < 60000", emp => emp.TotalSales<60000);

			Console.ReadKey();
		}
	}
	public class Reports
	{

		public delegate bool IllegableSales(EMP emp);

		public void ProcessEmployee(EMP[] employees, string title, IllegableSales isllegable)
		{
			Console.WriteLine(title);
			Console.WriteLine("********************************************");
			foreach (var emp in employees)
			{
				if (isllegable(emp))
					Console.WriteLine(emp);
			}
		}
	}
	public class EMP
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Gender { get; set; }
		public decimal TotalSales { get; set; }

		public override string ToString() => $"Id:{Id}, Name:{Name}, Gender:{Gender}, TotalSales:{TotalSales}";
	}
}

