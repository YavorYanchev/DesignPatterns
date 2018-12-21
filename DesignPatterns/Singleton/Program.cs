using System;

namespace Singleton
{
	public class Singleton
	{
		private Singleton()
		{
		}

		// ReSharper disable once ClassNeverInstantiated.Local
		private class SingletonCreator
		{
			static SingletonCreator()
			{
			}

			internal static readonly Singleton UniqueInstance = new Singleton();
		}

		public static Singleton Instance => SingletonCreator.UniqueInstance;
	}

	internal class Program
	{
		private static void Main()
		{
			var instance = Singleton.Instance;
			var secondInstance = Singleton.Instance;
			Console.WriteLine(instance.Equals(secondInstance));
			Console.WriteLine($"First instance hash code {instance.GetHashCode()}");
			Console.WriteLine($"Second instance hash code {secondInstance.GetHashCode()}");
		}
	}
}
