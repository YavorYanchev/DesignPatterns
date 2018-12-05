using System;

namespace Seabird_Adapter
{
	//ITarget
	public interface IAircraft
	{
		bool Airbourne { get; }

		void TakeOff();

		int Height { get; }
	}

	//Target
	public sealed class Aircraft : IAircraft
	{
		public Aircraft()
		{
			Height = 0;
			Airbourne = false;
		}

		public bool Airbourne { get; private set; }

		public int Height { get; private set; }

		public void TakeOff()
		{
			Console.WriteLine("Aircraft engine takeoff");
			Airbourne = true;
			Height = 200;
		}
	}

	//Adaptee interface
	public interface ISeacraft
	{
		int Speed { get; }

		void IncreaseRevs();
	}

	//Adaptee implementation
	public class Seacraft : ISeacraft
	{
		public int Speed { get; private set; }
		public virtual void IncreaseRevs()
		{
			Speed += 10;
			Console.WriteLine("Seacraft engine increases revs to " + Speed + " knots");
		}
	}

	//Adapter
	public class Seabird : Seacraft, IAircraft
	{
		public bool Airbourne => Height > 50;

		public void TakeOff()
		{
			while (!Airbourne)
			{
				IncreaseRevs();
			}
		}

		public int Height { get; private set; }

		public override void IncreaseRevs()
		{
			base.IncreaseRevs();
			if (Speed > 40)
				Height += 100;
		}
	}

	internal class TwoWayAdapter
	{
		private static void Main()
		{
			//No adapter
			Console.WriteLine("Experiment 1: test the aircraft engine");
			IAircraft aircraft = new Aircraft();
			aircraft.TakeOff();
			if (aircraft.Airbourne)
				Console.WriteLine($"The aircraft engine is fine, flying at {aircraft.Height} meters");

			//With adapter
			Console.WriteLine();
			Console.WriteLine("Experiment 2: Use the engine in Seabird");
			IAircraft seabird = new Seabird();
			seabird.TakeOff(); //And automatically increases speed
			Console.WriteLine("The seabird took off");

			//Two-way adapter: using seacraft instructions on an IAircraft object
			//where they are not in the IAircraft interface)
			Console.WriteLine("\nExperiment3: Increase the speed of the Seabird");
			((ISeacraft)seabird).IncreaseRevs();
			((ISeacraft)seabird).IncreaseRevs();

			if (seabird.Airbourne)
				Console.WriteLine($"Seabird flying at height {seabird.Height} meteres and speed {((ISeacraft)seabird).Speed} knots");
			Console.WriteLine("Experiment successful; the Seabird flies!");
		}
	}
}
