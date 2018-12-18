using System;

namespace Factory
{
	internal interface IProduct
	{
		string ShippedFrom { get; }
	}

	internal class AvocadoFromSouthAfrica : IProduct
	{
		public string ShippedFrom => "South Africa avocado";
	}

	internal class AvocadoFromSpain : IProduct
	{
		public string ShippedFrom => "Spain avocado";
	}

	internal class NotAvailableProduct : IProduct
	{
		public string ShippedFrom => "Not available product";
	}

	internal class Creator
	{
		public IProduct GetProductBasedOnMonth(int month)
		{
			if (month >= 4 && month <= 11)
				return new AvocadoFromSouthAfrica();

			if (month == 1 || month == 2 || month == 12)
				return new AvocadoFromSpain();

			return new NotAvailableProduct();
		}
	}

	internal class Program
	{
		private static void Main()
		{
			var creator = new Creator();

			for (var i = 1; i <= 12; i++)
			{
				var product = creator.GetProductBasedOnMonth(i);
				Console.WriteLine(product.ShippedFrom);
			}
		}
	}
}
