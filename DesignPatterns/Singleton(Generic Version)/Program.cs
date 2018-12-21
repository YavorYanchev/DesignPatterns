using System;

namespace Singleton_Generic_Version_
{
	public class Singleton<T> where T : class, new()
	{
		private Singleton() { }

		// ReSharper disable once ClassNeverInstantiated.Local
		private class SingletonCreator
		{
			static SingletonCreator()
			{
			}

			//private object instantiated with private constructor
			internal static readonly T UniqueInstance = new T();
		}

		public static T Instance => SingletonCreator.UniqueInstance;
	}

	internal class CoolClass { }

	internal class AnotherClass { }


	internal class Client
	{
		private static void Main()
		{
			var coolInstance = Singleton<CoolClass>.Instance;
			var secondCoolInstance = Singleton<CoolClass>.Instance;

			var anotherInstance = Singleton<AnotherClass>.Instance;

			if (coolInstance == secondCoolInstance)
			{
				Console.WriteLine("Objects are the same instance");
			}

			Console.WriteLine($"Another instance is of type {anotherInstance.GetType().Name}");
		}
	}
}
