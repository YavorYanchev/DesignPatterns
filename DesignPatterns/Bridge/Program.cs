using System;

namespace Bridge
{
	internal class Abstraction
	{
		private readonly IBridge _bridge;

		public Abstraction(IBridge implementation)
		{
			_bridge = implementation;
		}

		public string Operation()
		{
			return "Abstraction" + " <<< BRIDGE >>>" + _bridge.OperationImpl();
		}
	}

	interface IBridge
	{
		string OperationImpl();
	}

	internal class ImplementationA : IBridge
	{
		public string OperationImpl()
		{
			return "ImplementationA";
		}
	}

	internal class ImplementationB : IBridge
	{
		public string OperationImpl()
		{
			return "ImplementationB";
		}
	}

	internal class Program
    {
	    private static void Main()
        {
	        Console.WriteLine("Bridge Pattern\n");
	        Console.WriteLine(new Abstraction(new ImplementationA()).Operation());
	        Console.WriteLine(new Abstraction(new ImplementationB()).Operation());
        }
    }
}
