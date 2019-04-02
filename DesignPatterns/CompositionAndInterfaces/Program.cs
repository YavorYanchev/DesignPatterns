using System;

namespace CompositionAndInterfaces
{
	internal interface IVisible
	{
		void Draw();
	}

	internal class Invisible : IVisible
	{
		public void Draw()
		{
			Console.WriteLine("I won't appear.");
		}
	}

	internal class Visible : IVisible
	{
		public void Draw()
		{
			Console.WriteLine("I'm showing myself.");
		}
	}

	internal interface ICollidable
	{
		void Colide();
	}

	internal class Solid : ICollidable
	{
		public void Colide()
		{
			Console.WriteLine("Bang!");
		}
	}

	internal class NotSolid : ICollidable
	{
		public void Colide()
		{
			Console.WriteLine("Splash!");
		}
	}

	internal interface IUpdatable
	{
		void Update();
	}

	internal class Movable : IUpdatable
	{
		public void Update()
		{
			Console.WriteLine("Moving forward.");
		}
	}

	internal class NotMovable : IUpdatable
	{
		public void Update()
		{
			Console.WriteLine("I'm staying put.");
		}
	}


	internal class Program
	{
		private static void Main()
		{
			var player = new Player();
			player.Update();
			player.Colide();
			player.Draw();
		}
	}
}
