using System;

namespace Abstract_Factory
{
	internal class Program
	{
		private static void Main()
		{
			//call Client twice
			new Client<Poochy>().ClientMain();
			Console.WriteLine();

			new Client<Gucci>().ClientMain();
			Console.WriteLine();

			new Client<Groundcover>().ClientMain();
			Console.WriteLine();
		}
	}
}
