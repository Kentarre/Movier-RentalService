using System;

namespace FileService
{
    class Program
    {
        static void Main(string[] args)
        {
            var serverAppHost = new FileServiceHost();
            serverAppHost.Init();
            serverAppHost.Start("http://localhost:1404/");

            Console.WriteLine("Server running.  Press enter to terminate...");
            Console.ReadKey();
        }
    }
}
