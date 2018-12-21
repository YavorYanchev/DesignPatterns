namespace Abstract_Factory
{
	internal interface IFactory<TBrand>
		where TBrand: IBrand, new ()
	{
		IBag CreateBag();

		IShoes CreateShoes();
	}
}