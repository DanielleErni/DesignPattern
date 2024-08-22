// Step 1: Define the Component interface
public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Step 2: Create a Concrete Component
//base component
public class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple Coffee";
    }

    public double GetCost()
    {
        return 5.0;
    }
}

// Step 3: Create a Decorator interface
public interface ICoffeeDecorator : ICoffee
{
    ICoffee Coffee { get; set; }
}

// Step 4: Create Concrete Decorators
public class MilkDecorator : ICoffeeDecorator
{
    public ICoffee Coffee { get; set; }

    public MilkDecorator(ICoffee coffee)
    {
        Coffee = coffee;
    }

    public string GetDescription()
    {
        return Coffee.GetDescription() + ", Milk";
    }

    public double GetCost()
    {
        return Coffee.GetCost() + 1.5;
    }
}

public class SugarDecorator : ICoffeeDecorator
{
    public ICoffee Coffee { get; set; }

    public SugarDecorator(ICoffee coffee)
    {
        Coffee = coffee;
    }

    public string GetDescription()
    {
        return Coffee.GetDescription() + ", Sugar";
    }

    public double GetCost()
    {
        return Coffee.GetCost() + 0.5;
    }
}

// Step 5: Demonstrate the Decorator pattern
public class Program
{
    public static void Main()
    {
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost()}");

        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost()}");

        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost()}");

        coffee = new MilkDecorator(coffee); // Adding another layer of Milk
        Console.WriteLine($"{coffee.GetDescription()} costs {coffee.GetCost()}");
    }
}