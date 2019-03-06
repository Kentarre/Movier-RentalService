using System;
using FileService.Helpers;
using PdfSharpCore.Fonts;

namespace FileService
{
    class Program
    {
        static void Main(string[] args)
        {
            var serverAppHost = new FileServiceHost();
            serverAppHost.Init();
            serverAppHost.Start("http://localhost:1404/");

            GlobalFontSettings.FontResolver = new FontResolver();

            Console.WriteLine("Server running.  Press enter to terminate...");
            Console.ReadKey();
        }
    }
}
