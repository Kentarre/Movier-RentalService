using System;

namespace CalculationService
{
    class Program
    {
        static void Main(string[] args)
        {
            var serverAppHost = new CalculationServiceHost();
            serverAppHost.Init();
            serverAppHost.Start("http://localhost:1400/");

            Console.WriteLine("Server running.  Press enter to terminate...");
            Console.ReadKey();
        }
    }
}
