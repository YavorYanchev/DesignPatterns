using System;
using System.Collections.Generic;

namespace SpaceBook_Proxy
{
    class SpaceBookSystem
    {
        //Subject
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
        public class MySpaceBook
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
                    _mySpaceBook.Add(friend, _name + " said: "+ message);
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
    }



    class ProxyPattern : SpaceBookSystem
    {
        
        static void Main()
        { 
            //Enter Judith as name :)

            var me = new MySpaceBook();
            me.Add("Hello world");
            me.Add("Today I worked 18 hours");

            var tom = new MySpaceBook();
            tom.Poke("Judith");
            tom.Add("Judith", "Poor you");
            tom.Add("Off to see the Lion King tonight");

        }
    }
}
