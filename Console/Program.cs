
using System;
using ProducteurConsomatteur;
using System.Threading;



namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Exemple1.Execute(50000);
            System.Console.WriteLine("[ END ]");
            System.Console.ReadKey();
        }


    }
}
