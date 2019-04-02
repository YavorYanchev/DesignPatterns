namespace CompositionAndInterfaces
{
	internal class Cloud : GameObject
	{
		public Cloud() : base(new Visible(), new Movable(), new NotSolid())
		{
		}
	}
}
