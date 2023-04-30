using System;


namespace MyClasses.Models
{
	public class Manager
	{
		public string? fname { get; private set; }
		public string? lname { get; private set; }
		private int _id { get; set; }
		private double _salary { get; set; }
		public double bonus { get; private set; }

		private Manager(string? fname, string? lname, int id, double salary, double bonus)
		{
			this.fname=fname;
			this.lname=lname;
			_id=id;
			this.salary=salary;
			this.bonus=bonus;
		}
		public static Manager Create(string? fname,string? lname, int id,double salary,double bonus)
		{
			return new Manager(fname,lname,id,salary,bonus);
		}
		public void setName(string? fname,string? lname)
		{
			if (string.IsNullOrWhiteSpace(fname) || string.IsNullOrWhiteSpace(lname))
			{
				throw new ArgumentException("Invalid Input");		
			}
			else
			{
				this.fname=fname;
				this.lname=lname;
			}
		}
		public int id
		{
			get { return _id; }
			set { _id=value; }
		}
		public double salary
		{
			get { return _salary+bonus; }
			set { _salary=value; }
		}
		public void setBonus(double b) => bonus=b;
		public double getBonus() =>bonus;

		public override string? ToString()
		{
			return $"[**Manager**]\nFirst Name:{fname}\nLast Name:{lname}\nId:{_id}\nSalary:{salary}\n";
		}
		
	}
}
