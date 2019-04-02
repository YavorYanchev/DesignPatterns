namespace CompositionAndInterfaces
{
	internal abstract class GameObject : IVisible, IUpdatable, ICollidable
	{
		private readonly IVisible _visible;
		private readonly IUpdatable _updatable;
		private readonly ICollidable _collidable;

		protected GameObject(IVisible visible, IUpdatable updatable, ICollidable collidable)
		{
			_visible = visible;
			_updatable = updatable;
			_collidable = collidable;
		}

		public void Draw()
		{
			_visible.Draw();
		}

		public void Update()
		{
			_updatable.Update();
		}

		public void Colide()
		{
			_collidable.Colide();
		}
	}
}
