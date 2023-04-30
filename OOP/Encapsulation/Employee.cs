using System;
namespace MyClasses.Models
{
	/* Encapsulation */
	public class Employee
	{
		public static double TAX;
		public string? _fname { get;  private set; }
		public string? _lname { get; private set; }
		public double _wage { get; private set; }
		private int _loggedHours { get; set; }
		
		private Employee(string? fname, string? lname, double wage, int loggedHours)
		{
			_fname=fname;
			_lname=lname;
			_wage=wage;
			_loggedHours=loggedHours;
		}
		/* Factory Method */  
		public static Employee Create(string? fname,string? lname,double wage,int loggedHours)
		{
			return new Employee(fname,lname,wage,loggedHours);
		}
		
		/* Setter Method For The [First name & Last name */
		public void setName(string? fname,string? lname)
		{
			if (string.IsNullOrWhiteSpace(fname) ||string.IsNullOrWhiteSpace(lname))
				throw new ArgumentException("Invalid Input");
			_fname=fname;
			_lname=lname;
		}
		public double wage
		{
			get { return _wage; }
		}
		public void setWage(Object obj,double amount)
		{
			if (obj is not Manager)
			{
				throw new ArithmeticException("Invalid Operation");
			}
			else
			{
				_wage=amount;
			}
        }
		public int loggedHours
		{
			get { return _loggedHours; }
			set { _loggedHours=value; }
		}
		private double netSalary() => _wage* _loggedHours - (_wage* _loggedHours * TAX);


		public override string ToString()
		{
			return $"[**Employee**]\nFirst Name:{_fname}\nLast Name: {_lname}\nWage: {_wage}" +
				$"\nLoggedHours: {_loggedHours}\nNet Salary: {netSalary()}";
		}
		
	}
}
