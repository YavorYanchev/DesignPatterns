namespace Abstract_Factory
{
	internal class Factory<TBrand> : IFactory<TBrand>
		where TBrand : IBrand, new()
	{
		public IBag CreateBag()
		{
			return new Bag<TBrand>();
		}

		public IShoes CreateShoes()
		{
			return new Shoes<TBrand>();
		}
	}
}