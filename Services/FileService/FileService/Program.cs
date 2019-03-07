using System;
using System.Reflection;
using FileService.Helpers;
using PdfSharpCore.Fonts;

namespace FileService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = Assembly.GetExecutingAssembly().GetName().Name;

            var serverAppHost = new FileServiceHost();
            serverAppHost.Init();
            serverAppHost.Start("http://localhost:1404/");

            GlobalFontSettings.FontResolver = new FontResolver();

            Console.WriteLine("Server running.  Press enter to terminate...");
            Console.ReadKey();
        }
    }
}
