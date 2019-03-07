using System;
using System.Reflection;

namespace InventoryService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = Assembly.GetExecutingAssembly().GetName().Name;

            var serverAppHost = new InvenotryServiceHost();
            serverAppHost.Init();
            serverAppHost.Start("http://localhost:1402/");

            Console.WriteLine("Server running.  Press enter to terminate...");
            Console.ReadKey();
        }
    }
}
