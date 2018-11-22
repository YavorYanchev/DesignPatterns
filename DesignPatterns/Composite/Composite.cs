using System.Collections.Generic;
using System.Text;

namespace Composite
{
	public class Composite<T>:IComponent<T>
    {
	    private readonly List<IComponent<T>> _components;
	    private IComponent<T> _holder;

	    public Composite(T name)
	    {
		    Name = name;
			_components = new List<IComponent<T>>();
	    }

	    public T Name { get; set; }

		public void Add(IComponent<T> component)
	    {
			_components.Add(component);
	    }

	    public IComponent<T> Remove(T name)
	    {
		    _holder = this;
		    var item = _holder.Find(name);
		    if (_holder == null) return this;
		    ((Composite<T>) _holder)._components.Remove(item);
		    return _holder;
	    }

	    public string Display(int depth)
	    {
			var sb = new StringBuilder(new string('-', depth));
		    sb.Append("Set " + Name + " length :" + _components.Count + "\n");
		    foreach (var component in _components)
		    {
			    sb.Append(component.Display(depth + 2));
		    }

		    return sb.ToString();
	    }

	    public IComponent<T> Find(T name)
	    {
		    _holder = this;
		    if (Name.Equals(name))
			    return this;

		    IComponent<T> found = null;
		    foreach (var component in _components)
		    {
			    found = component.Find(name);
			    if (found != null)
				    break;
		    }
		    return found;
		}
	}
}
