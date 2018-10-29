using System;

namespace Proxy
{
    class SubjectAccessor
    {
        public interface ISubject
        {
            string Request();
        }


        private class Subject
        {
            public string Request()
            {
                return "Subject Request " + "Choose left door\n";
            }
        }

        public class Proxy : ISubject
        {
            private Subject _subject;


            public string Request()
            {
                //a virtual proxy creates the object only on its first method call
                if (_subject == null)
                {
                    Console.WriteLine("Subject inactive");
                    _subject = new Subject();
                }

                Console.WriteLine("Subject active");
                return "Proxy: Call to " + _subject.Request();
            }
        }

        //An authentication proxy first asks for a password
        public class ProtectionProxy : ISubject
        {
            private Subject _subject;
            private string password = "Abracadabra";

            public string Authenticate(string supplied)
            {
                if (!string.Equals(supplied, password, StringComparison.Ordinal))
                    return "Protection Proxy: No access";

                _subject = new Subject();
                return "Protection Proxy: Authenticated";
            }

            public string Request()
            {
                if (_subject == null)
                    return "Protection Proxy: Authenticate first";

                return "Protection Proxy: Call to " + _subject.Request();
            }
        }
    }

    

    class Client : SubjectAccessor
    {
        static void Main()
        {
            Console.WriteLine("Proxy pattern\n");
            ISubject subject = new Proxy();
            Console.WriteLine(subject.Request());
            Console.WriteLine(subject.Request());

            var protectionProxy = new ProtectionProxy();
            Console.WriteLine(protectionProxy.Request());
            Console.WriteLine(protectionProxy.Authenticate("Secret"));
            Console.WriteLine(protectionProxy.Authenticate("Abracadabra"));
            Console.WriteLine(protectionProxy.Request());
        }
    }
}
