using System;
using System.Collections.Generic;

namespace OpenBook_Bridge
{
	internal class SpaceBookSystem
	{
		private class SpaceBook 
		{
			private static readonly SortedList<string, SpaceBook> Community
				= new SortedList<string, SpaceBook>(100);

			private string _pages;
			private readonly string _name;
			private readonly string _gap = "\n\t\t\t\t";

			internal SpaceBook(string name)
			{
				_name = name;
				Community[name] = this;
			}

			public static bool IsUnique(string name)
			{
				return !Community.ContainsKey(name);
			}

			internal void Add(string post)
			{
				_pages += _gap + post;
				Console.WriteLine(_gap + "=====" + _name + "'s SpaceBook =====");
				Console.WriteLine(_pages);
				Console.WriteLine(_gap + "=============");
			}

			internal void Add(string friend, string message)
			{
				Community[friend].Add(message);
			}

			internal void Poke(string who, string friend)
			{
				Community[who]._pages += _gap + friend + " poked you";
			}
		}


		//The proxy
		//Combination of virtual and authentication proxy
		public class MySpaceBook : IBridge
		{
			private SpaceBook _mySpaceBook;
			private string _password;
			private string _name;
			private bool _loggedIn;

			void Register()
			{
				Console.WriteLine("Let's register you for SpaceBook");
				do
				{
					Console.WriteLine("All SpaceBook names must be unique");
					Console.WriteLine("Type in a user name: ");
					_name = Console.ReadLine();
				} while (!SpaceBook.IsUnique(_name));

				Console.WriteLine("Type in a password: ");
				_password = Console.ReadLine();
				Console.WriteLine("Thanks for registering with SpaceBook");

			}

			private void Authenticate()
			{
				Console.WriteLine("Welcome " + _name + ". Please type in your password: ");
				var supplied = Console.ReadLine();
				if (supplied == _password)
				{
					_loggedIn = true;
					Console.WriteLine("Logged into SpaceBook");
					if (_mySpaceBook == null)
						_mySpaceBook = new SpaceBook(_name);
					return;
				}

				Console.WriteLine("Incorrect password");
			}

			public void Add(string message)
			{
				Check();
				if (_loggedIn)
					_mySpaceBook.Add(message);
			}

			public void Add(string friend, string message)
			{
				Check();
				if (_loggedIn)
					_mySpaceBook.Add(friend, _name + " said: " + message);
			}

			public void Poke(string who)
			{
				Check();
				if (_loggedIn)
					_mySpaceBook.Poke(who, _name);
			}

			void Check()
			{
				if (_loggedIn) return;
				if (_password == null)
					Register();
				if (_mySpaceBook == null)
					Authenticate();
			}
		}

		

		public class MyOpenBook : IBridge
		{
			private readonly string _name;
			private readonly SpaceBook _myOpenBook;
			private static int _users;

			public MyOpenBook(string name)
			{
				_name = name;
				_users++;
				_myOpenBook = new SpaceBook(name + "-" + _users);
			}

			public void Add(string message)
			{
				_myOpenBook.Add(message);
			}

			public void Add(string friend, string message)
			{
				_myOpenBook.Add(friend, _name + " : " + message);
			}

			public void Poke(string who)
			{
				_myOpenBook.Poke(who, _name);
			}
		}	
	}

	internal interface IBridge
	{
		void Add(string message);

		void Add(string friend, string message);

		void Poke(string who);
	}

	internal class Portal
	{
		private readonly IBridge _bridge;
		public Portal(IBridge bridge)
		{
			_bridge = bridge;
		}

		public void Add(string message)
		{
			_bridge.Add(message);
		}

		public void Add(string friend, string message)
		{
			_bridge.Add(friend, message);
		}

		public void Poke(string who)
		{
			_bridge.Poke(who);
		}
	}


	internal static class OpenBookExtensions
	{
		public static void SuperPoke(this Portal me, string who, string what)
		{
			me.Add(who, what+ " you" );
		}
	}


	internal class Program : SpaceBookSystem
    {
	    private static void Main()
        {
			var me = new Portal(new MyOpenBook("Judith"));
			me.Add("Hello world");
			me.Add("Today I worked 18 hours.");

			var tom = new Portal(new MyOpenBook("Tom"));
			tom.Poke("Judith-1");
			tom.SuperPoke("Judith-1", "hugged");
			tom.Add("Judith-1", "Poor you");
			tom.Add("Hey, I'm on OpenBook - it's cool!");

	        var john = new Portal(new MySpaceBook());
	        john.Add("Hey, I'm on MySpace - it's not cool! :( ");
		}
    }
}
