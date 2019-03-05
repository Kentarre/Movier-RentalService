using System;

namespace RentalService
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serverAppHost = new RentalServiceHost();
            serverAppHost.Init();
            serverAppHost.Start("http://localhost:1401/");

            Console.WriteLine("Server running.  Press enter to terminate...");
            Console.ReadKey();
        }
    }
}
