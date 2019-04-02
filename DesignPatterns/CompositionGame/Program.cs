using System;

namespace CompositionGame
{
	class Program
	{
		static void Main(string[] args)
		{
			// I am not the author of this example
			// Link to the original https://scottlilly.com/c-design-patterns-composition-over-inheritance/
			// The author is Scott Lilly
			// Great post about composition over inheritance!!!

			var camel = MonsterFactory.CreateMonster(MonsterFactory.MonsterType.Camel);
			Console.WriteLine(camel.CanPunch);
			Console.WriteLine(camel.SpitDamage);
		}
	}
}
