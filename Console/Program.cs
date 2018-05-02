
using System;
using ProducteurConsomateur;
using System.Threading;



namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Exemple1.Execute(60000);
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("[ END ]");
            System.Console.ReadKey();
        }


    }
}
