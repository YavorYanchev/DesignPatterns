namespace Abstract_Factory
{
	internal class Shoes<TBrand> : IShoes
		where TBrand:IBrand, new ()
	{
		private readonly TBrand _brand;
		public Shoes()
		{
			_brand = new TBrand();
		}

		public decimal Price => _brand.Price;
	}
}