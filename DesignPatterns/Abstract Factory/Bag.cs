namespace Abstract_Factory
{
	internal class Bag<TBrand> : IBag
		where TBrand:IBrand, new ()
	{
		private readonly TBrand _brand;
		public Bag()
		{
			_brand = new TBrand();
		}

		public string Material => _brand.Material;
	}
}