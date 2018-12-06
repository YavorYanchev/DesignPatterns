using System;

namespace Adapter_Pluggable_
{
	internal class Adaptee
	{
		public double Precise(double numerator, double denominator)
		{
			return numerator / denominator;
		}
	}

	internal class Target
	{
		public string Estimate(int i)
		{
			return "Estimate is" + (int) Math.Round(i / 3.0);
		}
	}

	internal class Adapter : Adaptee
	{
		public Func<int, string> Request;

		//Different constuctors for the expected targets/adaptees

		//Adapter-Adaptee
		public Adapter(Adaptee adaptee)
		{
			Request = i => "Estimate based on precision is " + (int) Math.Round(adaptee.Precise(i, 3));
		}

		//Adapter-Target
		public Adapter(Target target)
		{
			//set delegate to the existing standart
			Request = target.Estimate;
		}
	}

	internal class Program
	{
		private static void Main()
		{
			var adapter = new Adapter(new Adaptee());
			Console.WriteLine(adapter.Request(5));

			var adapterUsingTarget = new Adapter(new Target());
			Console.WriteLine(adapterUsingTarget.Request(5));
		}
	}
}
