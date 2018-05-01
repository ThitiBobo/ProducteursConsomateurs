
using System;
using ProducteurConsomatteur;
using System.Threading;



namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Exemple1.Execute(6000);
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("[ END ]");
            System.Console.ReadKey();
        }


    }
}
