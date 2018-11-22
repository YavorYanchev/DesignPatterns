namespace Composite
{
	public interface IComponent<T>
	{
		void Add(IComponent<T> component);

		IComponent<T> Remove(T name);

		string Display(int depth);

		IComponent<T> Find(T name);

		T Name { get; set; }
	}
}
