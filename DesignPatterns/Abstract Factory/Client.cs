using System;

namespace Abstract_Factory
{
	internal class Client<TBrand>
		where TBrand : IBrand, new()
	{
		public void ClientMain() //IFactory<Brand> factory
		{
			IFactory<TBrand> factory = new Factory<TBrand>();

			var bag = factory.CreateBag();
			var shoes = factory.CreateShoes();

			Console.WriteLine($"I bought a Bag which is made from {bag.Material}");
			Console.WriteLine($"I bought some shoes which cost {shoes.Price}");
		}
	}
}