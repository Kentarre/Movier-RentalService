using System;
using System.Reflection;

namespace CalculationService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = Assembly.GetExecutingAssembly().GetName().Name;

            var serverAppHost = new CalculationServiceHost();
            serverAppHost.Init();
            serverAppHost.Start("http://localhost:1400/");

            Console.WriteLine("Server running.  Press enter to terminate...");
            Console.ReadKey();
        }
    }
}
