namespace CompositionAndInterfaces
{
	internal class Building : GameObject
	{
		public Building() : base(new Visible(), new NotMovable(), new Solid())
		{
		}
	}
}
