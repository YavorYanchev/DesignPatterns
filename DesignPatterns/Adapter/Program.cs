using System;

namespace Adapter
{

	//Existing way requests are implemented
	internal class Adaptee
	{
		//provide full precision
		public double SpecificRequest(double numerator, double denominator)
		{
			return numerator / denominator;
		}
	}

	internal interface ITarget
	{
		//Rough estimate required
		string Request(int i);
	}

	internal class Adapter : Adaptee, ITarget
	{
		public string Request(int i)
		{
			return "Rough estimate is " + (int)Math.Round(SpecificRequest(i, 3));
		}
	}

	internal class Client
	{
		private static void Main()
		{
			//adaptee in standalone mode
			var adaptee = new Adaptee();
			Console.WriteLine("Before the new standard\nPrecise reading: ");
			Console.WriteLine(adaptee.SpecificRequest(5, 3));

			//What the client really wants
			ITarget adapter = new Adapter();
			Console.WriteLine("\nMoving to the new standard");
			Console.WriteLine(adapter.Request(5));
		}
	}
}
