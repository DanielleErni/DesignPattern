using System;

namespace RealWorldFactoryMethod
{
    // Step 1: Create an interface for the product
    public interface ITransport
    {
        void Deliver();
    }

    // Step 2: Create concrete products that implement the interface
    public class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivering by land in a truck.");
        }
    }

    public class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivering by sea in a ship.");
        }
    }
    public class Airplane : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivering by airplane.");
        }
    }

    // Step 3: Create an interface for the factory
    public interface ITransportFactory
    {
        ITransport CreateTransport();
    }

    // Step 4: Create concrete factories that implement the factory interface
    public class TruckFactory : ITransportFactory
    {
        public ITransport CreateTransport()
        {
            return new Truck();
        }
    }

    public class ShipFactory : ITransportFactory
    {
        public ITransport CreateTransport()
        {
            return new Ship();
        }
    }

    // Step 5: Use the Factory Method in the main program
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Truck using TruckFactory
            ITransport truck = new TruckFactory().CreateTransport();
            truck.Deliver();  // Output: Delivering by land in a truck.

            // Create a Ship using ShipFactory
            ITransport ship = new ShipFactory().CreateTransport();
            ship.Deliver();  // Output: Delivering by sea in a ship.
        }
    }
}