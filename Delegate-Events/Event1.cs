using System;
using First_Csharp;
using MyClasses.Models.DelegateAndEvent;
using MyClasses.Models.DelegatesAndEvents;

namespace First_Csharp.Basic_and_OOP
{

    public class Event1
    {
        public static void Main(String[] args)
        {
            var market = new Market("SuperMarket_1");
            var market_management = new MarketManagement();

            Console.WriteLine("Enter The latset market profit");
            market.Profit=Convert.ToDouble(Console.ReadLine());

            market_management.OnProfit+=Market_OnProfit;  // Subscribe to the event

	    market_management.ChangeProfit(market,100000);   // Up 
            market_management.ChangeProfit(market, -4000);   // Down
            market_management.ChangeProfit(market, 14000);   // Up
            market_management.ChangeProfit(market,0.0);  // No Change

            market_management.OnProfit-=Market_OnProfit; // Unsubscripe to the event




            Console.ReadKey();
        }

        /* Event Handler Method */
	private static void Market_OnProfit(Market market,double oldprofit)
        {
            string? sign = "";
            if(market.Profit > oldprofit)
            {
                sign="UP";
                Console.ForegroundColor=ConsoleColor.Green;
            }
            else if( market.Profit < oldprofit)
            {
                sign="DOWN";
                Console.ForegroundColor=ConsoleColor.Red;
            }
            else
            {
                sign="No Change";
                Console.ForegroundColor=ConsoleColor.Gray;
            }
            Console.WriteLine($"{market} {sign}");
        }
	}
    
    public class MarketManagement
    {

		public delegate void PorfitHandler(Market market, double oldprofit);

		public event PorfitHandler OnProfit;
		public void ChangeProfit(Market market,double profit)
		{
			double oldprofit = market.Profit;
			market.Profit+=profit;
			OnProfit?.Invoke(market, oldprofit); // Firing The Event
		}
	}
	
    public class Market
    {
        private readonly string? _name;
        private double _profit { get; set; }

		public string? Name
        {
            get => _name;
        }
        public double Profit
        {
            get => _profit;
            set => _profit=value;
        }
        
        public Market(string? name)
        {
            _name=name;
        }
        
        public override string ToString() => $"Name: {_name} Profit: ${_profit}";
	}
}
