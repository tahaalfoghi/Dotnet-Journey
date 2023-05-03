using System;
using First_Csharp;
using MyClasses.Models.DelegateAndEvent;
using MyClasses.Models.DelegatesAndEvents;

namespace First_Csharp.Basic_and_OOP
{

    public class Event2
    {
        public static void Main(String[] args)
        {
            var stock_management = new StockManagement();
            var stock1 = new Stock("ARAMKO");

            Console.Write("Enter Stock latest price: ");
            stock1.Price=Convert.ToDecimal(Console.ReadLine());
			stock_management.OnChange+=Stock_OnChange;
			stock_management.ChangePrice(stock1,0.03m);
			stock_management.ChangePrice(stock1,-0.01m);
			stock_management.ChangePrice(stock1,0.0m);




            Console.ReadKey();
        }
        private static void Stock_OnChange(Stock stock,decimal oldprice)
        {
			     string? sign = "";
			     if (stock.Price > oldprice)
			     {
				    sign="UP";
				    Console.ForegroundColor=ConsoleColor.Green;
			     }
			     else if (stock.Price < oldprice)
			     {
			      	sign="DOWN";
				      Console.ForegroundColor=ConsoleColor.Red;
			     }
			     else
			     {
				     sign="No Change";
				     Console.ForegroundColor=ConsoleColor.Gray;
			     }
			     Console.WriteLine($"{stock} {sign}");
		   }

    }
	public class Stock
	{
		private readonly string? _name;
		private decimal _price { get; set; }
		public string? Name => _name;
		public decimal Price
		{
			get => _price;
			set => _price=value;
		}
		public Stock(string? name)
		{
			_name=name;
		}
		public override string? ToString() => $"Name :{_name}  Price: ${_price}";
	}
	public class StockManagement
	{

		public delegate void StockChangeHandler(Stock stock, decimal oldprice);
		public event StockChangeHandler OnChange;
		public void ChangePrice(Stock stock, decimal percent)
		{
			decimal oldprice = stock.Price;
			stock.Price+=Math.Round(stock.Price* percent, 2);

			OnChange?.Invoke(stock, oldprice); // Firing the Event
		}
	}
}
