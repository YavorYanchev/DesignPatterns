using System;

namespace Composite
{
	public class Component<T> : IComponent<T>
    {
	    public Component(T name)
	    {
		    Name = name;
	    }
	    public void Add(IComponent<T> component)
	    {
		    Console.WriteLine("Cannot add to an item");
	    }

	    public IComponent<T> Remove(T name)
	    {
		    Console.WriteLine("Cannot remove directly");
		    return this;
	    }

	    public string Display(int depth)
	    {
			return $"{new string('-', depth)}{Name}{'\n'}";
	    }

	    public IComponent<T> Find(T name)
	    {
		    return name.Equals(Name) ? this : null;
	    }

	    public T Name { get; set; }
    }
}
