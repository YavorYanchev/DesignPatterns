namespace CompositionAndInterfaces
{
	internal class Player : GameObject
	{
		public Player() : base(new Visible(), new Movable(), new Solid())
		{
		}
	}
}
