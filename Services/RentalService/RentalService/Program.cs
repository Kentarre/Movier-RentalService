using System;
using System.Reflection;

namespace RentalService
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = Assembly.GetExecutingAssembly().GetName().Name;

            var serverAppHost = new RentalServiceHost();
            serverAppHost.Init();
            serverAppHost.Start("http://localhost:1401/");

            Console.WriteLine("Server running.  Press enter to terminate...");
            Console.ReadKey();
        }
    }
}
