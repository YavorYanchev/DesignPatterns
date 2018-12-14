using System;

namespace Facade
{
	internal class SubsystemA
	{
		internal string A1()
		{
			return $"Subsystem A, Method A1{Environment.NewLine}";
		}

		internal string A2()
		{
			return $"Subsystem A, Method A2{Environment.NewLine}";
		}
	}

	internal class SubsystemB
	{
		internal string B1()
		{
			return $"Subsystem B, Method B1{Environment.NewLine}";
		}
	}

	internal class SubsystemC
	{
		internal string C1()
		{
			return $"Subsystem C, Method C1{Environment.NewLine}";
		}
	}

	public static class Facade
	{
		private static readonly SubsystemA SubsystemA  = new SubsystemA();
		private static readonly SubsystemB SubsystemB  = new SubsystemB();
		private static readonly SubsystemC SubsystemC  = new SubsystemC();

		public static void Operation1()
		{
			Console.WriteLine($"Operation1 {SubsystemA.A1()}{SubsystemA.A2()}{SubsystemB.B1()}");
		}

		public static void Operation2()
		{
			Console.WriteLine($"Operation2 {SubsystemB.B1()}{SubsystemC.C1()}");
		}
	}

	internal class Program
	{
		private static void Main()
		{
			Facade.Operation1();
			Facade.Operation2();
		}
	}
}
