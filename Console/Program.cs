
using System;
using ProducteurConsomateur;
using System.Threading;



namespace Console
{
    class Program
    {
        public const int SECONDE = 1000;
        public const int MINUTE = 60 * SECONDE;

        static void Main(string[] args)
        {
            Exemple1.Execute(30 * MINUTE);

            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("[ END ]");
            System.Console.ReadKey();
        }


    }
}
