namespace CompositionAndInterfaces
{
	internal class Trap : GameObject
	{
		public Trap() : base(new Invisible(), new NotMovable(), new Solid())
		{
		}
	}
}
