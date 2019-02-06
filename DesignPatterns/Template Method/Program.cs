using System;

namespace Template_Method
{
	internal interface IPrimitives
	{
		string Operation1();

		string Operation2();
	}

	internal class Algorithm
	{
		public void TemplateMethod(IPrimitives primitives)
		{
			var result = primitives.Operation1() +
			             primitives.Operation2();

			Console.WriteLine(result);
		}
	}

	internal class ClassA : IPrimitives
	{
		public string Operation1()
		{
			return "ClassA:Op1 ";
		}

		public string Operation2()
		{
			return "ClassA:Op2 ";
		}
	}

	internal class ClassB : IPrimitives
	{
		public string Operation1()
		{
			return "ClassB:Op1 ";
		}

		public string Operation2()
		{
			return "ClassB:Op2 ";
		}
	}

	internal class Program
	{
		private static void Main()
		{
			var algorithm = new Algorithm();
			algorithm.TemplateMethod(new ClassA());
			algorithm.TemplateMethod(new ClassB());
		}
	}
}
