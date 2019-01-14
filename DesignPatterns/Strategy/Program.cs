using System;

namespace Strategy
{
	internal interface IStrategy
	{
		int Move(Context context);
	}

	internal class Strategy1 : IStrategy
	{
		public int Move(Context context)
		{
			return ++context.Counter;
		}
	}

	internal class Strategy2 : IStrategy
	{
		public int Move(Context context)
		{
			return --context.Counter;
		}
	}


	internal class Context
	{
		public const int Start = 5;
		public int Counter = 5;

		private IStrategy _strategy = new Strategy1();

		public int Algorithm()
		{
			return _strategy.Move(this);
		}

		public void SwitchStrategy()
		{
			if (_strategy is Strategy1)
				_strategy = new Strategy2();
			else 
				_strategy = new Strategy1();
		}

	}

	internal class Program
	{
		private static void Main()
		{
			var context = new Context();
			context.SwitchStrategy();
			var r  = new Random(37);
			for (var i = Context.Start; i <= Context.Start + 15; i++)
			{
				if (r.Next(3) == 2)
				{
					Console.Write("|| ");
					context.SwitchStrategy();
				}

				Console.Write(context.Algorithm() + " ");
			}

			Console.WriteLine();
		}
	}
}
