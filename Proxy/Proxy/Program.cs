using System;

public class ProxyPatternExample
{
    // Define the Service Interface
    public interface IService
    {
        void Request();
    }

    // Implement the Real Service
    public class RealService : IService
    {
        public void Request()
        {
            Console.WriteLine("RealService: Handling request.");
        }
    }

    // Implement the Proxy Service
    public class ProxyService : IService
    {
        private RealService _realService;

        public ProxyService(RealService realService)
        {
            _realService = realService;
        }

        public void Request()
        {
            if (CheckAccess())
            {
                _realService.Request();
                LogAccess();
            }
        }

        private bool CheckAccess()
        {
            // Simulate access control
            Console.WriteLine("ProxyService: Checking access prior to firing a real request.");
            return true;
        }

        private void LogAccess()
        {
            // Simulate logging
            Console.WriteLine("ProxyService: Logging the time of request.");
        }
    }

    // Client Code
    public static void Main(string[] args)
    {
        RealService realService = new RealService();
        ProxyService proxyService = new ProxyService(realService);

        Console.WriteLine("Client: Executing the client code with a real service:");
        realService.Request();

        Console.WriteLine();

        Console.WriteLine("Client: Executing the same client code with a proxy:");
        proxyService.Request();
    }
}