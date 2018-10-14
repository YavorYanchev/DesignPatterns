using System;

namespace Decorator
{
    public interface IComponent
    {
        string Operation();
    }

    public class Component : IComponent
    {
        public string Operation()
        {
            return "I am walking ";
        }
    }

    public class DecoratorA : IComponent
    {
        private readonly IComponent _component;

        public DecoratorA(IComponent component)
        {
            _component = component;
        }

        public string Operation()
        {
            string operation = _component.Operation();
            operation += "and listening to Classic FM ";

            return operation;
        }
    }

    public class DecoratorB : IComponent
    {
        private IComponent _component;

        public DecoratorB(IComponent component)
        {
            _component = component;
        }

        public string AddedState { get; } = "past the Coffe Shop ";

        public string Operation()
        {
            var operation = _component.Operation();
            operation += "to school";

            return operation;
        }

        public string AddedBehaviour()
        {
            return "and I bought a cappuccino ";
        }
    }

    

    class Program
    {
        static void Display(string message, IComponent component)
        {
            Console.WriteLine(message + component.Operation());
        }

        static void Main()
        {
            Console.WriteLine("Decorator pattern!\n");
            var component = new Component();
            Display("1. Basic component: ", component);
            Display("2. A-decorated: ", new DecoratorA(component));
            Display("3. B-decorated: ", new DecoratorB(component));
            Display("4. B-A-decorated: ", new DecoratorB(new DecoratorA(component)));

            //Explicit Decorator B
            var decoratorB = new DecoratorB(new Component());
            Display("5. A-B-decorated: ", new DecoratorA(decoratorB));

            //Invoking its added state and added behaviour
            Console.WriteLine("\t\t\t" + decoratorB.AddedState + decoratorB.AddedBehaviour());
        }
    }
}
