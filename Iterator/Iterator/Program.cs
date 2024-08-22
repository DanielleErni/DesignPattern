namespace Iterator;

// The 'Iterator' interface
public interface IIterator<T>
{
    T Current { get; }
    bool MoveNext();
    void Reset();
}

// The 'Aggregate' interface
public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

// The 'ConcreteIterator' class
public class ConcreteIterator<T> : IIterator<T>
{
    private readonly List<T> _collection;
    private int _currentIndex = -1;

    public ConcreteIterator(List<T> collection)
    {
        _collection = collection;
    }

    public T Current => _collection[_currentIndex];

    public bool MoveNext()
    {
        if (_currentIndex + 1 < _collection.Count)
        {
            _currentIndex++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        _currentIndex = -1;
    }
}

// The 'ConcreteAggregate' class
public class ConcreteAggregate<T> : IAggregate<T>
{
    private readonly List<T> _items = new List<T>();

    public IIterator<T> CreateIterator()
    {
        return new ConcreteIterator<T>(_items);
    }

    public void AddItem(T item)
    {
        _items.Add(item);
    }
}

// Client code
public class Program
{
    public static void Main(string[] args)
    {
        // Create a collection
        var collection = new ConcreteAggregate<string>();
        collection.AddItem("Item 1");
        collection.AddItem("Item 2");
        collection.AddItem("Item 3");

        // Create an iterator
        var iterator = collection.CreateIterator();

        // Traverse the collection using the iterator
        while (iterator.MoveNext())
        {
            Console.WriteLine(iterator.Current);
        }
    }
}