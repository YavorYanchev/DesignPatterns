using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer_Strategy
{
	internal interface IBillingStrategy
	{
		double GetActPrice(double rawPrice);
	}

	/// <summary>
	/// Normal billing strategy(unchanged price)
	/// </summary>
	internal class NormalBillingStrategy : IBillingStrategy
	{
		public double GetActPrice(double rawPrice)
		{
			return rawPrice;
		}
	}

	internal class HappyHourStrategy : IBillingStrategy
	{
		public double GetActPrice(double rawPrice)
		{
			return rawPrice * 0.5;
		}
	}


	internal class Customer
	{
		private readonly IList<double> _drinksPrices;

		public Customer(IBillingStrategy strategy)
		{
			_drinksPrices = new List<double>();
			Strategy = strategy;
		}

		public void Add(double price, int quantity)
		{
			_drinksPrices.Add(Strategy.GetActPrice(price * quantity));
		}

		public void PrintBill()
		{
			var sum = _drinksPrices.Sum();

			Console.WriteLine("Total due: " + sum);
			_drinksPrices.Clear();
		}

		public IBillingStrategy Strategy { get; set; }
	}

	internal class Program
	{
		private static void Main()
		{
			//Prepare strategies
			var normalStrategy = new NormalBillingStrategy();
			var happyHourStrategy = new HappyHourStrategy();

			var firstCustomer = new Customer(normalStrategy);

			//normal billing
			firstCustomer.Add(1.00, 1);

			//Start Happy Hour
			firstCustomer.Strategy = happyHourStrategy;
			firstCustomer.Add(1.00, 2);

			//New Customer
			var secondCustomer = new Customer(happyHourStrategy);
			secondCustomer.Add(0.80, 1);

			//First customer pays
			firstCustomer.PrintBill();

			//End Happy hour
			secondCustomer.Strategy = normalStrategy;
			secondCustomer.Add(1.30, 2);
			secondCustomer.Add(2.50, 1);
			secondCustomer.PrintBill();
		}
	}
}
