using System;

namespace InventoryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var serverAppHost = new InvenotryServiceHost();
            serverAppHost.Init();
            serverAppHost.Start("http://localhost:1402/");

            Console.WriteLine("Server running.  Press enter to terminate...");
            Console.ReadKey();
        }
    }
}
